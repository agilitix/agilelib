namespace AxMsmq.Interfaces
{
    public interface IQueueReceiver<out TQueueMessage> : IQueue where TQueueMessage : class
    {
        TQueueMessage Receive();
        TQueueMessage Peek();
    }
}