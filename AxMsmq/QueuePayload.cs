using System;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueuePayload<T> : IQueuePayload<T> where T : class
    {
        public string Label { get; set; }
        public T Body { get; set; }
    }
}
