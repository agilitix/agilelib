using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Threading;
using AxMsmq;
using AxMsmq.Interfaces;

namespace AxMsmqSample
{
    public class MyMessage
    {
        public string Content { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IMessageFormatter formatter = new XmlMessageFormatter(new[] {typeof(MyMessage)});
            IQueueMessageTransformer<MyMessage, Message> transformer = new QueueMessageTransformer<MyMessage>();

            IQueuesFactory<IQueueMessage<MyMessage>> pqm = new PrivateQueuesFactory<MyMessage>(formatter, transformer);

            IList<IQueueUri> queues = pqm.GetExistingQueues("localhost");

            IQueueUri first = queues.First();

            IQueueSender<IQueueMessage<MyMessage>> sender = pqm.GetOrCreateSender(first);

            IQueueMessage<MyMessage> message = new QueueMessage<MyMessage>();
            message.Label = "Hello world!";
            message.Content = new MyMessage
                           {
                               Content = "My first message payload."
                           };

            sender.Send(message);

            Thread.Sleep(1000);

            IQueueReceiver<IQueueMessage<MyMessage>> receiver = pqm.GetOrCreateReceiver(first);
            IQueueMessage<MyMessage> messageReceived = receiver.Receive();

            Console.ReadLine();
        }
    }
}
