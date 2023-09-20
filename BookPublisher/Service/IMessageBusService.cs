namespace BookPublisher.Service
{
    public interface IMessageBusService
    {
        void Publish(object data, string queue);
    }
}