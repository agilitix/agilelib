using System.Net;
using System.Text;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueAddress : IQueueAddress
    {
        public string Host { get; }
        public string QueueName { get; }
        public string Address { get; }

        /// <summary>
        /// Host = "host_name"
        /// QueueName = "private$\name"
        /// Address = "FormatName:DIRECT=OS:host_name\private$\name"
        /// 
        /// Host = "192.168.10.150"
        /// QueueName = "private$\name"
        /// Address = "FormatName:DIRECT=TCP:192.168.10.150\private$\name"
        /// </summary>
        public QueueAddress(string host, string queueName)
        {
            Host = host.ToLower();
            QueueName = queueName.ToLower();

            IPAddress ip;
            Address = "FormatName:DIRECT=" + (IPAddress.TryParse(host, out ip) ? "TCP:" : "OS:") + host + @"\" + QueueName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(nameof(Host));
            sb.Append("=");
            sb.Append(Host);
            sb.Append(", ");
            sb.Append(nameof(QueueName));
            sb.Append("=");
            sb.Append(QueueName);
            sb.Append(", ");
            sb.Append(nameof(Address));
            sb.Append("=");
            sb.Append(Address);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
