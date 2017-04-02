using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueSender<TContent, TTransportMessage> : IQueueSender<IQueueMessage<TContent>> where TContent : class where TTransportMessage : Message
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<TContent, TTransportMessage> _transformer;

        public IQueueUri Uri { get; }

        public QueueSender(MessageQueue messageQueue, IQueueMessageTransformer<TContent, TTransportMessage> transformer)
        {
            _messageQueue = messageQueue;
            _transformer = transformer;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public void Send(IQueueMessage<TContent> content)
        {
            TTransportMessage transportMessage = _transformer.Transform(content);
            _messageQueue.Send(transportMessage);
        }
    }
}