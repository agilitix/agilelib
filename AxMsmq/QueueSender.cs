using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueSender<T> : IQueueSender<IQueuePayload<T>> where T : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<IQueuePayload<T>, Message> _transformer;

        public IQueueUri Uri { get; }

        public QueueSender(MessageQueue messageQueue, IQueueMessageTransformer<IQueuePayload<T>, Message> transformer)
        {
            _messageQueue = messageQueue;
            _transformer = transformer;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public void Send(IQueuePayload<T> payload)
        {
            Message message = _transformer.Transform(payload);
            _messageQueue.Send(message);
        }
    }
}