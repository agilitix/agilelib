using System;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueListener<TContent> : IQueueListener<IQueueMessage<TContent>> where TContent : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<TContent, Message> _transformer;

        public IQueueUri Uri { get; }

        public event Action<object, IQueueMessage<TContent>> OnReceiveMessage;
        public event Action<object, IQueueMessage<TContent>> OnPeekMessage;

        public QueueListener(MessageQueue messageQueue, IQueueMessageTransformer<TContent, Message> transformer)
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
            Message transportMessage = messageQueue.EndPeek(e.AsyncResult);
            IQueueMessage<TContent> content = _transformer.Transform(transportMessage);
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
            Message transportMessage = messageQueue.EndReceive(e.AsyncResult);
            IQueueMessage<TContent> content = _transformer.Transform(transportMessage);
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