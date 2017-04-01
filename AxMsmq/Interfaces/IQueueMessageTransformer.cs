namespace AxMsmq.Interfaces
{
    public interface IQueueMessageTransformer<TContent, TTransportMessage> where TContent : class where TTransportMessage : class
    {
        IQueueMessage<TContent> Transform(TTransportMessage transportMessage);
        TTransportMessage Transform(IQueueMessage<TContent> messageContent);
    }
}