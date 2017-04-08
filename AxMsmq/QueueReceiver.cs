using System;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueReceiver<TContent, TTransportMessage> : IQueueReceiver<IQueueMessage<TContent>> where TContent : class where TTransportMessage : Message
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageTransformer<TContent, TTransportMessage> _transformer;

        public IQueueAddress Address { get; }

        public event Action<object /*sender*/, IQueueMessage<TContent>> OnReceiveMessage;
        public event Action<object /*sender*/, IQueueMessage<TContent>> OnPeekMessage;

        public QueueReceiver(MessageQueue messageQueue, IQueueMessageTransformer<TContent, TTransportMessage> transformer)
        {
            _messageQueue = messageQueue;
            _transformer = transformer;
            Address = new QueueAddress(messageQueue.MachineName, messageQueue.QueueName);
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

        public void AsyncReceive()
        {
            _messageQueue.ReceiveCompleted += ReceiveHandler;
            _messageQueue.BeginReceive();
        }

        public void AsyncPeek()
        {
            _messageQueue.PeekCompleted += PeekHandler;
            _messageQueue.BeginPeek();
        }

        private void PeekHandler(object sender, PeekCompletedEventArgs e)
        {
            MessageQueue messageQueue = (MessageQueue)sender;
            TTransportMessage transportMessage = (TTransportMessage)messageQueue.EndPeek(e.AsyncResult);
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
            MessageQueue messageQueue = (MessageQueue)sender;
            TTransportMessage transportMessage = (TTransportMessage)messageQueue.EndReceive(e.AsyncResult);
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
