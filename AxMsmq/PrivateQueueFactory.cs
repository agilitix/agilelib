using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class PrivateQueueFactory<TContent, TTransportMessage> : IQueueFactory<IQueueMessage<TContent>> where TContent : class where TTransportMessage : Message
    {
        private readonly IMessageFormatter _messageFormatter;
        private readonly IQueueMessageTransformer<TContent, TTransportMessage> _messageTransformer;

        public PrivateQueueFactory(IQueueMessageTransformer<TContent, TTransportMessage> messageTransformer)
            : this(new XmlMessageFormatter(new[] {typeof(TContent)}), messageTransformer)
        {
        }

        public PrivateQueueFactory(IMessageFormatter messageFormatter, IQueueMessageTransformer<TContent, TTransportMessage> messageTransformer)
        {
            _messageFormatter = messageFormatter;
            _messageTransformer = messageTransformer;
        }

        public IList<IQueueAddress> GetExistingQueues(string hostName)
        {
            IEnumerable<IQueueAddress> privateQueues = MessageQueue.GetPrivateQueuesByMachine(hostName)
                                                                   .Select(x => new QueueAddress(x.MachineName, x.QueueName));
            return privateQueues.ToList();
        }

        public IQueueReceiver<IQueueMessage<TContent>> GetOrCreateReceiver(IQueueAddress address)
        {
            return GetOrCreate(address, q => new QueueReceiver<TContent, TTransportMessage>(q, _messageTransformer));
        }

        public IQueueSender<IQueueMessage<TContent>> GetOrCreateSender(IQueueAddress address)
        {
            return GetOrCreate(address, q => new QueueSender<TContent, TTransportMessage>(q, _messageTransformer));
        }

        private TQueue GetOrCreate<TQueue>(IQueueAddress address, Func<MessageQueue, TQueue> builder)
        {
            MessageQueue queue = null;

            try
            {
                queue = GetQueue(address) ?? MessageQueue.Create(address.Address);
                queue.Formatter = _messageFormatter.Clone() as IMessageFormatter;
            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.QueueExists)
                {
                    queue = GetQueue(address);
                }
            }

            return builder(queue);
        }

        private static MessageQueue GetQueue(IQueueAddress address)
        {
            return MessageQueue.GetPrivateQueuesByMachine(address.Host)
                               .FirstOrDefault(x => x.QueueName.Equals(address.QueueName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
