using System;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    internal class QueueListener<T> : IQueueListener<IQueueMessageContent<T>>
        where T : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageConverter<Message, IQueueMessageContent<T>> _converter;

        public IQueueUri Uri { get; }

        public event Action<object, IQueueMessageContent<T>> OnReceiveMessage;
        public event Action<object, IQueueMessageContent<T>> OnPeekMessage;

        public QueueListener(MessageQueue messageQueue, IQueueMessageConverter<Message, IQueueMessageContent<T>> converter)
        {
            _messageQueue = messageQueue;
            _converter = converter;
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
            IQueueMessageContent<T> content = _converter.Convert(message);
            try
            {
                OnPeekMessage?.Invoke(this, content);
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
            IQueueMessageContent<T> content = _converter.Convert(message);
            try
            {
                OnReceiveMessage?.Invoke(this, content);
            }
            finally
            {
                messageQueue.BeginReceive();
            }
        }
    }
}