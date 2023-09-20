using System.Text;
using System.Threading.Channels;
using BookConsumer.Data;
using BookConsumer.Entities;
using BookConsumer.Repositories;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BookConsumer.Service
{
    public class BookSubscriber : BackgroundService
    {
        private readonly IModel channel;
        private IBookRepository bookRepository;
        private readonly IServiceProvider serviceProvider;

        public BookSubscriber(IServiceProvider serviceProvider)
        {
            channel = RabbitMQContext.GetRabbitMqConnection();
            this.serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(channel);
 
            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var book = JsonConvert.DeserializeObject<Book>(contentString);

                var scope = serviceProvider.CreateScope();
                this.bookRepository = scope.ServiceProvider.GetRequiredService<IBookRepository>();

                bookRepository.Save(book);
                GC.SuppressFinalize(bookRepository);
                GC.SuppressFinalize(scope);
                channel.BasicAck(eventArgs.DeliveryTag, false);
            };
 
            channel.BasicConsume("book-queue", false, consumer);
 
            return Task.CompletedTask;
        }
    }
}