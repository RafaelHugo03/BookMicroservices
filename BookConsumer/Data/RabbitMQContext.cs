using RabbitMQ.Client;

namespace BookConsumer.Data
{
    public class RabbitMQContext
    {
        public static IModel GetRabbitMqConnection()
        {
            var connectionFactory = new ConnectionFactory{
                HostName = "localhost",
                UserName = "admin",
                Password = "123456"
            };
            var connection = connectionFactory.CreateConnection("BookPublisher");
            return connection.CreateModel();
        }
    }
}