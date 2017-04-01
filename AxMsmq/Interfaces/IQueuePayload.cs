namespace AxMsmq.Interfaces
{
    public interface IQueuePayload<T> where T : class
    {
        string Label { get; set; }
        T Body { get; set; }
    }
}
