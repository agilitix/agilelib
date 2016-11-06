using System;

namespace AxMsmq.Interfaces
{
    public interface IQueueListener : IQueue
    {
        event Action<object, IQueueMessage> OnMessage;

        void Listen();
    }
}
