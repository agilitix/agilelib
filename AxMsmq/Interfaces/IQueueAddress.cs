namespace AxMsmq.Interfaces
{
    public interface IQueueAddress
    {
        string Host { get; }
        string QueueName { get; }
        string Address { get; }
    }
}
