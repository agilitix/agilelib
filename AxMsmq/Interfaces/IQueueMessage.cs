namespace AxMsmq.Interfaces
{
    public interface IQueueMessage<T> where T : class
    {
        string Label { get; set; }
        T Content { get; set; }
    }
}
