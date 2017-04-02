using System;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueMessage<TContent> : IQueueMessage<TContent> where TContent : class
    {
        public string Label { get; set; }
        public TContent Content { get; set; }
    }
}
