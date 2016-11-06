using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    internal class PrivateQueuesManager : IQueuesManager
    {
        private readonly IMessageFormatter _messageFormatter;

        public PrivateQueuesManager()
            : this(new XmlMessageFormatter(new[] {typeof (string)}))
        {
        }

        public PrivateQueuesManager(IMessageFormatter messageFormatter)
        {
            _messageFormatter = messageFormatter;
        }

        public IList<IQueueUri> GetExisitingQueues(string host)
        {
            IEnumerable<IQueueUri> privateQueues = MessageQueue.GetPrivateQueuesByMachine(host)
                                                               .Select(x => new QueueUri(host, x.QueueName));
            return privateQueues.ToList();
        }

        public IQueueReceiver GetOrCreateReceiver(IQueueUri uri)
        {
            return GetOrCreate(uri, (u, q) => new QueueReceiver(u, q));
        }

        public IQueueSender GetOrCreateSender(IQueueUri uri)
        {
            return GetOrCreate(uri, (u, q) => new QueueSender(u, q));
        }

        public IQueueListener GetOrCreateListener(IQueueUri uri)
        {
            return GetOrCreate(uri, (u, q) => new QueueListener(u, q));
        }

        private T GetOrCreate<T>(IQueueUri uri, Func<IQueueUri, MessageQueue, T> builder)
        {
            MessageQueue queue = MessageQueue.GetPrivateQueuesByMachine(uri.Host)
                                             .FirstOrDefault(x => x.QueueName.Equals(uri.Path))
                                 ?? MessageQueue.Create(uri.Uri);
            queue.Formatter = _messageFormatter;
            return builder(uri, queue);
        }
    }
}