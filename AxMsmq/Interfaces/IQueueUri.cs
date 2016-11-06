namespace AxMsmq.Interfaces
{
    public interface IQueueUri
    {
        string Host { get; }
        string Path { get; }

        string Uri { get; }
    }
}
