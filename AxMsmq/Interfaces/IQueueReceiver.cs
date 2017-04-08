using System;

namespace AxMsmq.Interfaces
{
    public interface IQueueReceiver<out TQueueMessage> : IQueue where TQueueMessage : class
    {
        event Action<object /*sender*/, TQueueMessage> OnReceiveCompleted;
        event Action<object /*sender*/, TQueueMessage> OnPeekCompleted;

        void BeginReceive();
        void BeginPeek();

        TQueueMessage Receive();
        TQueueMessage Peek();

        TQueueMessage Receive(TimeSpan timeout);
        TQueueMessage Peek(TimeSpan timeout);
    }
}