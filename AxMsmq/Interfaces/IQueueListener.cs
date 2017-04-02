using System;

namespace AxMsmq.Interfaces
{
    public interface IQueueListener<out TQueueMessage> : IQueue where TQueueMessage : class
    {
        event Action<object, TQueueMessage> OnReceiveMessage;
        event Action<object, TQueueMessage> OnPeekMessage;

        void Receive();
        void Peek();
    }
}