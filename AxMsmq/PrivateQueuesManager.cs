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
        private readonly IQueueMessageConverter<IQueueMessageContent<T>, Message> _messageContentConverter;
        private readonly IQueueMessageConverter<Message, IQueueMessageContent<T>> _messageTransportConverter;

        public PrivateQueuesManager(IMessageFormatter messageFormatter,
                                    IQueueMessageConverter<IQueueMessageContent<T>, Message> messageContentConverter,
                                    IQueueMessageConverter<Message, IQueueMessageContent<T>> messageTransportConverter)
        {
            _messageFormatter = messageFormatter;
            _messageContentConverter = messageContentConverter;
            _messageTransportConverter = messageTransportConverter;
        }

        public IList<IQueueUri> GetExistingQueues(string hostName)
        {
            IEnumerable<IQueueUri> privateQueues = MessageQueue.GetPrivateQueuesByMachine(hostName)
                                                               .Select(x => new QueueUri(hostName, x.QueueName));
            return privateQueues.ToList();
        }

        public IQueueReceiver<IQueueMessageContent<T>> GetOrCreateReceiver(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueReceiver<T>(q, _messageTransportConverter));
        }

        public IQueueSender<IQueueMessageContent<T>> GetOrCreateSender(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueSender<T>(q, _messageContentConverter));
        }

        public IQueueListener<IQueueMessageContent<T>> GetOrCreateListener(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueListener<T>(q, _messageTransportConverter));
        }

        private TQueue GetOrCreate<TQueue>(IQueueUri uri, Func<MessageQueue, TQueue> builder)
        {
            MessageQueue queue = null;

            try
            {
                queue = MessageQueue.GetPrivateQueuesByMachine(uri.HostName)
                                    .FirstOrDefault(x => x.QueueName.Equals(uri.QueueName))
                        ?? MessageQueue.Create(uri.ConnectionString);

                queue.Formatter = _messageFormatter.Clone() as IMessageFormatter;
            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.QueueExists)
                {
                    queue = MessageQueue.GetPrivateQueuesByMachine(uri.HostName)
                                        .FirstOrDefault(x => x.QueueName.Equals(uri.QueueName));
                }
            }

            return builder(queue);
        }
    }
}
