using System;
using System.Net;
using AxMsmq.Interfaces;

namespace AxMsmq
{
    public class QueueUri : IQueueUri
    {
        public string Host { get; }
        public string Path { get; }
        public string Uri { get; }

        /// <summary>
        /// host = "host_name"
        /// path = "private$\\queue_name"
        /// </summary>
        public QueueUri(string host, string path)
            : this(host + ":" + path)
        {
        }

        /// <summary>
        /// "host_name:private$\\queue_name"
        /// </summary>
        public QueueUri(string uri)
        {
            string[] split = uri.Split(':');
            Host = split[0];
            Path = split[1];
            Uri = Host + "\\" + Path;

            IPHostEntry hostEntry = Dns.GetHostEntry(Host);
            if (hostEntry == null)
            {
                throw new ArgumentException(string.Format("Host {0} does not exists", Host));
            }
        }
    }
}