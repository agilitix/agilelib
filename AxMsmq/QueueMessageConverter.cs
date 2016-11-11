using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueMessageConverter<T> : IQueueMessageConverter<IQueueMessageContent<T>, Message>,
                                            IQueueMessageConverter<Message, IQueueMessageContent<T>>
        where T : class
    {
        public Message Convert(IQueueMessageContent<T> messageContent)
        {
            Message transportMessage = new Message
                              {
                                  Label = messageContent.Label,
                                  Body = messageContent.Payload
                              };
            return transportMessage;
        }

        public IQueueMessageContent<T> Convert(Message transportMessage)
        {
            IQueueMessageContent<T> messageContent = new QueueMessageContent<T>();
            messageContent.Label = transportMessage?.Label;
            messageContent.Payload = transportMessage?.Body as T;
            return messageContent;
        }
    }
}