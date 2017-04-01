using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueMessageTransformer<TContent> : IQueueMessageTransformer<TContent, Message> where TContent : class
    {
        public Message Transform(IQueueMessage<TContent> messageContent)
        {
            Message transportMessage = new Message
            {
                Label = messageContent.Label,
                Body = messageContent.Content
            };
            return transportMessage;
        }

        public IQueueMessage<TContent> Transform(Message transportMessage)
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
