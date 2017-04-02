namespace AxMsmq.Interfaces
{
    public interface IQueueMessage<TContent> where TContent : class
    {
        string Label { get; set; }
        TContent Content { get; set; }
    }
}
