namespace AxMsmq.Interfaces
{
    public interface IQueueUri
    {
        string HostName { get; }
        string QueueName { get; }
        string ConnectionString { get; }
    }
}
