using System.Net;
using System.Text;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueUri : IQueueUri
    {
        public string Host { get; }
        public string QueueName { get; }
        public string ConnectionString { get; }

        /// <summary>
        /// Host = "host_name"
        /// QueueName = "private$\name"
        /// ConnectionString = "FormatName:DIRECT=OS:host_name\private$\name"
        /// 
        /// Host = "192.168.10.150"
        /// QueueName = "private$\name"
        /// ConnectionString = "FormatName:DIRECT=TCP:192.168.10.150\private$\name"
        /// </summary>
        public QueueUri(string host, string queueName)
        {
            Host = host;
            QueueName = queueName;

            IPAddress ip;
            ConnectionString = "FormatName:DIRECT=" + (IPAddress.TryParse(host, out ip) ? "TCP:" : "OS:") + host + @"\" + queueName;
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
            sb.Append(nameof(ConnectionString));
            sb.Append("=");
            sb.Append(ConnectionString);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
