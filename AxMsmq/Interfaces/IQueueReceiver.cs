namespace AxMsmq.Interfaces
{
    public interface IQueueReceiver<out T> : IQueue
        where T : class
    {
        T Receive();
        T Peek();
    }
}