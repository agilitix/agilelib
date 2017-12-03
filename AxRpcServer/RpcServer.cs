using System.Collections.Generic;
using Grpc.Core;

namespace AxRpcServer
{
    public class RpcServer : IRpcServer
    {
        protected Server _server;

        public string Host { get; }
        public int Port { get; }

        public RpcServer(string host, int port, IEnumerable<IRpcService> services)
        {
            Host = host;
            Port = port;

            _server = new Server
                      {
                          Ports = {new ServerPort(host, port, ServerCredentials.Insecure)}
                      };

            foreach (IRpcService service in services)
            {
                _server.Services.Add(service.BindService());
            }
        }

        public void Start()
        {
            _server.Start();
        }

        public void Stop()
        {
            _server.ShutdownAsync();
        }
    }
}
