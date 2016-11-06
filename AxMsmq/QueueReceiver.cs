using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueReceiver : IQueueReceiver
    {
        private readonly MessageQueue _messageQueue;

        public IQueueUri Uri { get; }

        public QueueReceiver(IQueueUri uri, MessageQueue messageQueue)
        {
            Uri = uri;
            _messageQueue = messageQueue;
        }

        public IQueueMessage Receive()
        {
            Message m = _messageQueue.Receive();
            return m?.Body as IQueueMessage;
        }
    }
}
