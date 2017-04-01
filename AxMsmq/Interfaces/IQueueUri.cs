namespace AxMsmq.Interfaces
{
    public interface IQueueUri
    {
        string Host { get; }
        string QueueName { get; }
        string ConnectionString { get; }
    }
}
