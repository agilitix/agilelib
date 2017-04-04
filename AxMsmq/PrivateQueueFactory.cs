﻿using System;
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

        public IList<IQueueUri> GetExistingQueues(string hostName)
        {
            IEnumerable<IQueueUri> privateQueues = MessageQueue.GetPrivateQueuesByMachine(hostName)
                                                               .Select(x => new QueueUri(x.MachineName, x.QueueName));
            return privateQueues.ToList();
        }

        public IQueueReceiver<IQueueMessage<TContent>> GetOrCreateReceiver(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueReceiver<TContent, TTransportMessage>(q, _messageTransformer));
        }

        public IQueueSender<IQueueMessage<TContent>> GetOrCreateSender(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueSender<TContent, TTransportMessage>(q, _messageTransformer));
        }

        public IQueueListener<IQueueMessage<TContent>> GetOrCreateListener(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueListener<TContent, TTransportMessage>(q, _messageTransformer));
        }

        private TQueue GetOrCreate<TQueue>(IQueueUri uri, Func<MessageQueue, TQueue> builder)
        {
            MessageQueue queue = null;
            Func<MessageQueue> queueGetter = () => MessageQueue.GetPrivateQueuesByMachine(uri.Host)
                                                               .FirstOrDefault(x => x.QueueName.Equals(uri.QueueName,
                                                                                                       StringComparison.InvariantCultureIgnoreCase));

            try
            {
                queue = queueGetter() ?? MessageQueue.Create(uri.ConnectionString);
                queue.Formatter = _messageFormatter.Clone() as IMessageFormatter;
            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.QueueExists)
                {
                    queue = queueGetter();
                }
            }

            return builder(queue);
        }
    }
}
