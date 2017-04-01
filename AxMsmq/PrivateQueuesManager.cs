using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class PrivateQueuesManager<T> : IQueuesManager<IQueuePayload<T>> where T : class
    {
        private readonly IMessageFormatter _messageFormatter;
        private readonly IQueueMessageTransformer<IQueuePayload<T>, Message> _payloadToMessageTransformer;
        private readonly IQueueMessageTransformer<Message, IQueuePayload<T>> _messageToPayloadTransformer;

        public PrivateQueuesManager(IMessageFormatter messageFormatter,
                                    IQueueMessageTransformer<IQueuePayload<T>, Message> payloadToMessageTransformer,
                                    IQueueMessageTransformer<Message, IQueuePayload<T>> messageToPayloadTransformer)
        {
            _messageFormatter = messageFormatter;
            _payloadToMessageTransformer = payloadToMessageTransformer;
            _messageToPayloadTransformer = messageToPayloadTransformer;
        }

        public IList<IQueueUri> GetExistingQueues(string hostName)
        {
            IEnumerable<IQueueUri> privateQueues = MessageQueue.GetPrivateQueuesByMachine(hostName)
                                                               .Select(x => new QueueUri(x.MachineName, x.QueueName));
            return privateQueues.ToList();
        }

        public IQueueReceiver<IQueuePayload<T>> GetOrCreateReceiver(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueReceiver<T>(q, _messageToPayloadTransformer));
        }

        public IQueueSender<IQueuePayload<T>> GetOrCreateSender(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueSender<T>(q, _payloadToMessageTransformer));
        }

        public IQueueListener<IQueuePayload<T>> GetOrCreateListener(IQueueUri uri)
        {
            return GetOrCreate(uri, q => new QueueListener<T>(q, _messageToPayloadTransformer));
        }

        private TQueue GetOrCreate<TQueue>(IQueueUri uri, Func<MessageQueue, TQueue> builder)
        {
            MessageQueue queue = null;
            Func<MessageQueue> queueGetter = () => MessageQueue.GetPrivateQueuesByMachine(uri.Host)
                                                               .FirstOrDefault(x => x.QueueName.Equals(uri.QueueName));

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
