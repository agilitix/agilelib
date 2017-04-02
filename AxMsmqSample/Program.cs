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

            IList<IQueueUri> queues = privateQueuesFactory.GetExistingQueues("localhost");
            IQueueUri queueUri = queues.First();

            IQueueMessage<MessageContent> message = new QueueMessage<MessageContent>()
            {
                Label = "WelcomeMsg",
                Content = new MessageContent
                {
                    SaySomething = "Hello world!"
                }
            };

            IQueueSender<IQueueMessage<MessageContent>> sender = privateQueuesFactory.GetOrCreateSender(queueUri);
            sender.Send(message);

            Thread.Sleep(1000);

            IQueueReceiver<IQueueMessage<MessageContent>> receiver = privateQueuesFactory.GetOrCreateReceiver(queueUri);
            IQueueMessage<MessageContent> messageReceived = receiver.Receive();

            Console.ReadLine();
        }
    }
}
