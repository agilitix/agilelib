using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueReceiver<TContent, TTransportMessage> : IQueueReceiver<IQueueMessage<TContent>> where TContent : class where TTransportMessage : Message
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<TContent, TTransportMessage> _transformer;

        public IQueueUri Uri { get; }

        public QueueReceiver(MessageQueue messageQueue, IQueueMessageTransformer<TContent, TTransportMessage> transformer)
        {
            _messageQueue = messageQueue;
            _transformer = transformer;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public IQueueMessage<TContent> Receive()
        {
            TTransportMessage transportMessage = (TTransportMessage) _messageQueue.Receive();
            return _transformer.Transform(transportMessage);
        }

        public IQueueMessage<TContent> Peek()
        {
            TTransportMessage transportMessage = (TTransportMessage) _messageQueue.Peek();
            return _transformer.Transform(transportMessage);
        }
    }
}
