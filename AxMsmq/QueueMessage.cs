using System;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueMessage<T> : IQueueMessage<T> where T : class
    {
        public string Label { get; set; }
        public T Content { get; set; }
    }
}
