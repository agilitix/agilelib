using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueReceiver<T> : IQueueReceiver<IQueuePayload<T>> where T : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<Message, IQueuePayload<T>> _transformer;

        public IQueueUri Uri { get; }

        public QueueReceiver(MessageQueue messageQueue, IQueueMessageTransformer<Message, IQueuePayload<T>> transformer)
        {
            _messageQueue = messageQueue;
            _transformer = transformer;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public IQueuePayload<T> Receive()
        {
            Message message = _messageQueue.Receive();
            return _transformer.Transform(message);
        }

        public IQueuePayload<T> Peek()
        {
            Message message = _messageQueue.Peek();
            if (message != null)
            {
                message.Formatter = _messageQueue.Formatter;
            }
            return _transformer.Transform(message);
        }
    }
}
