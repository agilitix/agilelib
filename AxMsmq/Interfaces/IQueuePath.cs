namespace AxMsmq.Interfaces
{
    public interface IQueuePath
    {
        string Host { get; }
        string QueueName { get; }
        string Path { get; }
    }
}
