using System;

namespace AxMsmq.Interfaces
{
    public interface IQueueReceiver<out TQueueMessage> : IQueue where TQueueMessage : class
    {
        event Action<object /*sender*/, TQueueMessage> OnReceiveMessage;
        event Action<object /*sender*/, TQueueMessage> OnPeekMessage;

        void AsyncReceive();
        void AsyncPeek();

        TQueueMessage Receive();
        TQueueMessage Peek();
    }
}