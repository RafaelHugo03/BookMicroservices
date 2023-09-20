using System.Text;
using BookPublisher.Data;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BookPublisher.Service
{
    public class MessageBusService : IMessageBusService
    {
        private readonly IModel channel;

        public MessageBusService()
        {
            channel = RabbitMQContext.GetRabbitMqConnection();
        }
        public void Publish(object data, string queue)
        {
            var payload = JsonConvert.SerializeObject(data);
            var bytes = Encoding.UTF8.GetBytes(payload);

            channel.QueueDeclare(queue, false, false, false, null);
            channel.BasicPublish("", queue, null, bytes);
        }
    }
}