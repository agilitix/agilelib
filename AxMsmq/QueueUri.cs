using System.Text;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueUri : IQueueUri
    {
        public string HostName { get; }
        public string QueueName { get; }
        public string ConnectionString { get; }

        /// <summary>
        /// hostName = "host_name"
        /// queueName = "private$\\queue_name"
        /// </summary>
        public QueueUri(string hostName, string queueName)
        {
            HostName = hostName;
            QueueName = queueName;
            ConnectionString = hostName + @"\" + queueName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(nameof(HostName));
            sb.Append("=");
            sb.Append(HostName);
            sb.Append(",");
            sb.Append(nameof(QueueName));
            sb.Append("=");
            sb.Append(QueueName);
            sb.Append(",");
            sb.Append(nameof(ConnectionString));
            sb.Append("=");
            sb.Append(ConnectionString);
            sb.Append("}");
            return sb.ToString();
        }
    }
}