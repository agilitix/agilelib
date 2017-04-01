using System;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueListener<T> : IQueueListener<IQueuePayload<T>> where T : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<Message, IQueuePayload<T>> _transformer;

        public IQueueUri Uri { get; }

        public event Action<object, IQueuePayload<T>> OnReceiveMessage;
        public event Action<object, IQueuePayload<T>> OnPeekMessage;

        public QueueListener(MessageQueue messageQueue, IQueueMessageTransformer<Message, IQueuePayload<T>> transformer)
        {
            _messageQueue = messageQueue;
            _transformer = transformer;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public void Receive()
        {
            _messageQueue.ReceiveCompleted += ReceiveHandler;
            _messageQueue.BeginReceive();
        }

        public void Peek()
        {
            _messageQueue.PeekCompleted += PeekHandler;
            _messageQueue.BeginPeek();
        }

        private void PeekHandler(object sender, PeekCompletedEventArgs e)
        {
            MessageQueue messageQueue = (MessageQueue)sender;
            Message message = messageQueue.EndPeek(e.AsyncResult);
            IQueuePayload<T> payload = _transformer.Transform(message);
            try
            {
                OnPeekMessage?.Invoke(this, payload);
            }
            finally
            {
                messageQueue.BeginPeek();
            }
        }

        private void ReceiveHandler(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue messageQueue = (MessageQueue) sender;
            Message message = messageQueue.EndReceive(e.AsyncResult);
            IQueuePayload<T> payload = _transformer.Transform(message);
            try
            {
                OnReceiveMessage?.Invoke(this, payload);
            }
            finally
            {
                messageQueue.BeginReceive();
            }
        }
    }
}