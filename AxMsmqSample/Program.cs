using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Threading;
using AxMsmq;
using AxMsmq.Interfaces;

namespace AxMsmqSample
{
    public class MessageContent
    {
        public string SaySomething { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IQueueMessageTransformer<MessageContent, Message> transformer = new QueueMessageTransformer<MessageContent, Message>();
            IQueueFactory<IQueueMessage<MessageContent>> privateQueuesFactory = new PrivateQueueFactory<MessageContent, Message>(transformer);

            IList<IQueueAddress> queues = privateQueuesFactory.GetExistingQueues("localhost");
            IQueueAddress queueAddress = queues.First();

            IQueueMessage<MessageContent> message = new QueueMessage<MessageContent>()
            {
                Label = "WelcomeMsg",
                Content = new MessageContent
                {
                    SaySomething = "Hello world!"
                }
            };

            IQueueSender<IQueueMessage<MessageContent>> sender = privateQueuesFactory.GetOrCreateSender(queueAddress);
            sender.Send(message);

            Thread.Sleep(1000);

            IQueueReceiver<IQueueMessage<MessageContent>> receiver = privateQueuesFactory.GetOrCreateReceiver(queueAddress);
            IQueueMessage<MessageContent> messageReceived1 = receiver.Peek(TimeSpan.Zero);
            IQueueMessage<MessageContent> messageReceived2 = receiver.Receive(TimeSpan.Zero);

            Console.ReadLine();
        }
    }
}
