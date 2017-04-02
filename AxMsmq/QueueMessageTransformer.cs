using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueMessageTransformer<TContent, TTransportMessage> : IQueueMessageTransformer<TContent, TTransportMessage> where TContent : class where TTransportMessage : Message
    {
        public TTransportMessage Transform(IQueueMessage<TContent> queueMessage)
        {
            Message transportMessage = new Message
            {
                Label = queueMessage.Label,
                Body = queueMessage.Content
            };
            return (TTransportMessage) transportMessage;
        }

        public IQueueMessage<TContent> Transform(TTransportMessage transportMessage)
        {
            IQueueMessage<TContent> messageContent = new QueueMessage<TContent>
            {
                Label = transportMessage?.Label,
                Content = transportMessage?.Body as TContent
            };
            return messageContent;
        }
    }
}
