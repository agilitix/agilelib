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

        public IList<IQueuePath> GetExistingQueues(string hostName)
        {
            IEnumerable<IQueuePath> privateQueues = MessageQueue.GetPrivateQueuesByMachine(hostName)
                                                                .Select(x => new QueuePath(x.MachineName, x.QueueName));
            return privateQueues.ToList();
        }

        public IQueueReceiver<IQueueMessage<TContent>> GetOrCreateReceiver(IQueuePath path)
        {
            return GetOrCreate(path, q => new QueueReceiver<TContent, TTransportMessage>(q, _messageTransformer));
        }

        public IQueueSender<IQueueMessage<TContent>> GetOrCreateSender(IQueuePath path)
        {
            return GetOrCreate(path, q => new QueueSender<TContent, TTransportMessage>(q, _messageTransformer));
        }

        public bool CreateQueue(IQueuePath queuePath)
        {
            try
            {
                MessageQueue.Create(queuePath.Path);
                return true;
            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.QueueExists)
                {
                    return true;
                }

                throw;
            }
        }

        private TQueue GetOrCreate<TQueue>(IQueuePath queuePath, Func<MessageQueue, TQueue> builder)
        {
            MessageQueue queue = null;

            try
            {
                queue = GetQueue(queuePath) ?? MessageQueue.Create(queuePath.Path);
                queue.Formatter = _messageFormatter.Clone() as IMessageFormatter;
            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.QueueExists)
                {
                    queue = GetQueue(queuePath);
                }
            }

            return queue != null
                       ? builder(queue)
                       : default(TQueue);
        }

        private static MessageQueue GetQueue(IQueuePath queuePath)
        {
            return MessageQueue.GetPrivateQueuesByMachine(queuePath.Host)
                               .FirstOrDefault(x => x.QueueName.Equals(queuePath.QueueName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
