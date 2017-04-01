using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
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
            IQueueMessageTransformer<IQueuePayload<MyMessage>, Message> payloadTransformer = new QueueMessageTransformer<MyMessage>();
            IQueueMessageTransformer<Message, IQueuePayload<MyMessage>> messageTransformer = new QueueMessageTransformer<MyMessage>();

            IQueuesManager<IQueuePayload<MyMessage>> pqm = new PrivateQueuesManager<MyMessage>(formatter, payloadTransformer, messageTransformer);

            IList<IQueueUri> queues = pqm.GetExistingQueues("virgo");

            IQueueUri first = queues.First();

            IQueueSender<IQueuePayload<MyMessage>> sender = pqm.GetOrCreateSender(first);

            IQueuePayload<MyMessage> payload = new QueuePayload<MyMessage>();
            payload.Label = "Hello world!";
            payload.Body = new MyMessage
                           {
                               Content = "My first message payload."
                           };

            sender.Send(payload);

            Thread.Sleep(1000);

            IQueueReceiver<IQueuePayload<MyMessage>> receiver = pqm.GetOrCreateReceiver(first);
            IQueuePayload<MyMessage> msgRecv = receiver.Receive();
        }
    }
}
