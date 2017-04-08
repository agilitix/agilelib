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
            IQueueMessageTransformer<MessageContent, Message> messageTransformer = new QueueMessageTransformer<MessageContent, Message>();
            IQueueFactory<IQueueMessage<MessageContent>> privateQueueFactory = new PrivateQueueFactory<MessageContent, Message>(messageTransformer);

            IList<IQueueAddress> queues = privateQueueFactory.GetExistingQueues("localhost");
            IQueueAddress queueAddress = queues.First();

            IQueueMessage<MessageContent> message = new QueueMessage<MessageContent>()
            {
                Label = "WelcomeMsg",
                Content = new MessageContent
                {
                    SaySomething = "Hello world!"
                }
            };

            IQueueSender<IQueueMessage<MessageContent>> sender = privateQueueFactory.GetOrCreateSender(queueAddress);
            sender.Send(message);

            Thread.Sleep(1000);

            IQueueReceiver<IQueueMessage<MessageContent>> receiver = privateQueueFactory.GetOrCreateReceiver(queueAddress);
            IQueueMessage<MessageContent> messageReceived1 = receiver.Peek(TimeSpan.Zero);
            IQueueMessage<MessageContent> messageReceived2 = receiver.Receive(TimeSpan.Zero);

            Console.ReadLine();
        }
    }
}
