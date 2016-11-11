using System.Messaging;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueSender<T> : IQueueSender<IQueueMessageContent<T>>
        where T : class
    {
        private readonly MessageQueue _messageQueue;
        private readonly IQueueMessageConverter<IQueueMessageContent<T>, Message> _converter;

        public IQueueUri Uri { get; }

        public QueueSender(MessageQueue messageQueue, IQueueMessageConverter<IQueueMessageContent<T>, Message> converter)
        {
            _messageQueue = messageQueue;
            _converter = converter;
            Uri = new QueueUri(messageQueue.MachineName, messageQueue.QueueName);
        }

        public void Send(IQueueMessageContent<T> content)
        {
            Message message = _converter.Convert(content);
            message.Formatter = _messageQueue.Formatter;
            _messageQueue.Send(message);
        }
    }
}