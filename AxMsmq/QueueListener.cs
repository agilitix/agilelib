using System;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    internal class QueueListener : IQueueListener
    {
        private readonly MessageQueue _messageQueue;

        public IQueueUri Uri { get; }

        public event Action<object, IQueueMessage> OnMessage;

        public QueueListener(IQueueUri uri, MessageQueue messageQueue)
        {
            Uri = uri;
            _messageQueue = messageQueue;
        }

        public void Listen()
        {
            _messageQueue.ReceiveCompleted += Received;
            _messageQueue.BeginReceive();
        }

        private void Received(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue messageQueue = (MessageQueue) sender;
            Message message = messageQueue.EndReceive(e.AsyncResult);
            OnMessage?.Invoke(this, message.Body as IQueueMessage);
            messageQueue.BeginReceive();
        }
    }
}