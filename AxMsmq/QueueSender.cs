using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueSender : IQueueSender
    {
        private readonly MessageQueue _messageQueue;

        public IQueueUri Uri { get; }

        public QueueSender(IQueueUri uri, MessageQueue messageQueue)
        {
            Uri = uri;
            _messageQueue = messageQueue;
        }

        public void Send(IQueueMessage message)
        {
            _messageQueue.Send(message);
        }
    }
}
