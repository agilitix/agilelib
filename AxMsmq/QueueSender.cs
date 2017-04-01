using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueSender<TContent> : IQueueSender<IQueueMessage<TContent>> where TContent : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<TContent, Message> _transformer;

        public IQueueUri Uri { get; }

        public QueueSender(MessageQueue messageQueue, IQueueMessageTransformer<TContent, Message> transformer)
        {
            _messageQueue = messageQueue;
            _transformer = transformer;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public void Send(IQueueMessage<TContent> content)
        {
            Message transportMessage = _transformer.Transform(content);
            _messageQueue.Send(transportMessage);
        }
    }
}