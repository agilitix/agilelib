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

        public event Action<object /*sender*/, IQueueMessage<TContent>> OnReceiveCompleted;
        public event Action<object /*sender*/, IQueueMessage<TContent>> OnPeekCompleted;

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

        public IQueueMessage<TContent> Receive(TimeSpan timeout)
        {
            IQueueMessage<TContent> messageContent = TryGetMessage(() => (TTransportMessage) _messageQueue.Receive(timeout));
            return messageContent;
        }

        public IQueueMessage<TContent> Peek()
        {
            TTransportMessage transportMessage = (TTransportMessage) _messageQueue.Peek();
            return _transformer.Transform(transportMessage);
        }

        public IQueueMessage<TContent> Peek(TimeSpan timeout)
        {
            IQueueMessage<TContent> messageContent = TryGetMessage(() => (TTransportMessage) _messageQueue.Peek(timeout));
            return messageContent;
        }

        public void BeginReceive()
        {
            _messageQueue.ReceiveCompleted += ReceiveCompleted;
            _messageQueue.BeginReceive();
        }

        public void BeginPeek()
        {
            _messageQueue.PeekCompleted += PeekCompleted;
            _messageQueue.BeginPeek();
        }

        private void PeekCompleted(object sender, PeekCompletedEventArgs e)
        {
            MessageQueue messageQueue = (MessageQueue) sender;
            TTransportMessage transportMessage = (TTransportMessage) messageQueue.EndPeek(e.AsyncResult);
            IQueueMessage<TContent> content = _transformer.Transform(transportMessage);
            try
            {
                OnPeekCompleted?.Invoke(this, content);
            }
            finally
            {
                messageQueue.BeginPeek();
            }
        }

        private void ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue messageQueue = (MessageQueue) sender;
            TTransportMessage transportMessage = (TTransportMessage) messageQueue.EndReceive(e.AsyncResult);
            IQueueMessage<TContent> content = _transformer.Transform(transportMessage);
            try
            {
                OnReceiveCompleted?.Invoke(this, content);
            }
            finally
            {
                messageQueue.BeginReceive();
            }
        }

        public IQueueMessage<TContent> TryGetMessage(Func<TTransportMessage> getWithTimeout)
        {
            try
            {
                TTransportMessage transportMessage = getWithTimeout();
                return _transformer.Transform(transportMessage);
            }
            catch (MessageQueueException e)
            {
                if (e.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                {
                    return default(IQueueMessage<TContent>);
                }

                throw;
            }
        }
    }
}
