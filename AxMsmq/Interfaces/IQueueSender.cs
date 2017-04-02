namespace AxMsmq.Interfaces
{
    public interface IQueueSender<in TQueueMessage> : IQueue where TQueueMessage : class
    {
        void Send(TQueueMessage content);
    }
}