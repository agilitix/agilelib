using System;
using System.Linq;
using System.Net;
using System.Text;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueuePath : IQueuePath
    {
        public string Host { get; }
        public string QueueName { get; }
        public string Path { get; }

        /// <summary>
        /// Host = "host_name"
        /// QueueName = "private$\name"
        /// Path = "host_name\private$\name"
        /// </summary>
        public QueuePath(string host, string queueName)
        {
            IPAddress ip;
            if (IPAddress.TryParse(host, out ip))
            {
                throw new ArgumentException(nameof(host) + " param must be a valid host name (not an IP address) or '.' for localhost");
            }

            Host = host.Trim().ToLower();
            if (Host.Equals(".") || IsLocalhost(Host))
            {
                Host = Dns.GetHostName().ToLower();
            }

            QueueName = queueName.Trim().ToLower();
            Path = Host + @"\" + QueueName;
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
            sb.Append(nameof(Path));
            sb.Append("=");
            sb.Append(Path);
            sb.Append("}");
            return sb.ToString();
        }

        private static bool IsLocalhost(string host)
        {
            IPAddress[] hostIPs = Dns.GetHostAddresses(host);
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            return hostIPs.Any(ipAddress => IPAddress.IsLoopback(ipAddress) || localIPs.Contains(ipAddress));
        }
    }
}
