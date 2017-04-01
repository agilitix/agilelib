using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueMessageTransformer<T> : IQueueMessageTransformer<IQueuePayload<T>, Message>, IQueueMessageTransformer<Message, IQueuePayload<T>> where T : class
    {
        public Message Transform(IQueuePayload<T> queuePayload)
        {
            Message queueMessage = new Message
            {
                Label = queuePayload.Label,
                Body = queuePayload.Body
            };
            return queueMessage;
        }

        public IQueuePayload<T> Transform(Message queueMessage)
        {
            IQueuePayload<T> queuePayload = new QueuePayload<T>
            {
                Label = queueMessage?.Label,
                Body = queueMessage?.Body as T
            };
            return queuePayload;
        }
    }
}
