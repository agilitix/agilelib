using AxMsmq.Interfaces;

namespace AxMsmq
{
    class QueueMessageContent<T> : IQueueMessageContent<T>
        where T : class
    {
        public string Label { get; set; }
        public T Payload { get; set; }
    }
}
