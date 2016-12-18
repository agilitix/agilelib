using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueReceiver<T> : IQueueReceiver<IQueueMessageContent<T>>
        where T : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageConverter<Message, IQueueMessageContent<T>> _converter;

        public IQueueUri Uri { get; }

        public QueueReceiver(MessageQueue messageQueue, IQueueMessageConverter<Message, IQueueMessageContent<T>> converter)
        {
            _messageQueue = messageQueue;
            _converter = converter;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public IQueueMessageContent<T> Receive()
        {
            Message message = _messageQueue.Receive();
            return _converter.Convert(message);
        }

        public IQueueMessageContent<T> Peek()
        {
            Message message = _messageQueue.Peek();
            return _converter.Convert(message);
        }
    }
}