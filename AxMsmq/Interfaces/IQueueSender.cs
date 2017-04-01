namespace AxMsmq.Interfaces
{
    public interface IQueueSender<in T> : IQueue where T : class
    {
        void Send(T content);
    }
}