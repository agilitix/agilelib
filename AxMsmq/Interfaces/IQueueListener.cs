using System;

namespace AxMsmq.Interfaces
{
    public interface IQueueListener<out T> : IQueue
        where T : class
    {
        event Action<object, T> OnReceiveMessage;
        event Action<object, T> OnPeekMessage;

        void Receive();
        void Peek();
    }
}