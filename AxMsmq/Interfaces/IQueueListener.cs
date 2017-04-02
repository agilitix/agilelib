using System;

namespace AxMsmq.Interfaces
{
    public interface IQueueListener<out TQueueMessage> : IQueue where TQueueMessage : class
    {
        event Action<object /*sender*/, TQueueMessage> OnReceiveMessage;
        event Action<object /*sender*/, TQueueMessage> OnPeekMessage;

        void Receive();
        void Peek();
    }
}
