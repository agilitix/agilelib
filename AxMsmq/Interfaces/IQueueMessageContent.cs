namespace AxMsmq.Interfaces
{
    public interface IQueueMessageContent<T>
        where T : class
    {
        string Label { get; set; }
        T Payload { get; set; }
    }
}