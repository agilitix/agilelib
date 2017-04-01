using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueReceiver<TContent> : IQueueReceiver<IQueueMessage<TContent>> where TContent : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<TContent, Message> _transformer;

        public IQueueUri Uri { get; }

        public QueueReceiver(MessageQueue messageQueue, IQueueMessageTransformer<TContent, Message> transformer)
        {
            _messageQueue = messageQueue;
            _transformer = transformer;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public IQueueMessage<TContent> Receive()
        {
            Message transportMessage = _messageQueue.Receive();
            return _transformer.Transform(transportMessage);
        }

        public IQueueMessage<TContent> Peek()
        {
            Message transportMessage = _messageQueue.Peek();
            return _transformer.Transform(transportMessage);
        }
    }
}
