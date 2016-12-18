using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    internal class PrivateQueuesManager<T> : IQueuesManager<IQueueMessageContent<T>>
        where T : class
    {
        private readonly IMessageFormatter _messageFormatter;
        private readonly IQueueMessageConverter<IQueueMessageContent<T>, Message> _envelopConverter;
        private readonly IQueueMessageConverter<Message, IQueueMessageContent<T>> _messageConverter;

        public PrivateQueuesManager(IMessageFormatter messageFormatter,
            IQueueMessageConverter<IQueueMessageContent<T>, Message> envelopConverter,
            IQueueMessageConverter<Message, IQueueMessageContent<T>> messageConverter)
        {
            _messageFormatter = messageFormatter;
            _envelopConverter = envelopConverter;
            _messageConverter = messageConverter;
        }

        public IList<IQueueUri> GetExistingQueues(string hostName)
        {
            IEnumerable<IQueueUri> privateQueues = MessageQueue.GetPrivateQueuesByMachine(hostName)
                                                               .Select(x => new QueueUri(x.MachineName, x.QueueName))
                                                               .OrderBy(x => x.QueueName);
            return privateQueues.ToList();
        }

        public IQueueReceiver<IQueueMessageContent<T>> GetOrCreateReceiver(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueReceiver<T>(q, _messageConverter));
        }

        public IQueueSender<IQueueMessageContent<T>> GetOrCreateSender(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueSender<T>(q, _envelopConverter));
        }

        public IQueueListener<IQueueMessageContent<T>> GetOrCreateListener(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueListener<T>(q, _messageConverter));
        }

        private TQueue GetOrCreate<TQueue>(IQueueUri uri, Func<MessageQueue, TQueue> builder)
        {
            MessageQueue queue = MessageQueue.GetPrivateQueuesByMachine(uri.HostName)
                                             .FirstOrDefault(x => x.QueueName.Equals(uri.QueueName))
                                 ?? MessageQueue.Create(uri.ConnectionString);

            queue.Formatter = _messageFormatter.Clone() as IMessageFormatter;

            return builder(queue);
        }
    }
}