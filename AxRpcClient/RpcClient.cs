using System;
using Grpc.Core;

namespace AxRpcClient
{
    public class RpcClient<T> : IRpcClient<T> where T : ClientBase<T>
    {
        public T Client { get; }

        public RpcClient(string host, int port, Func<Channel, T> clientBuilder)
        {
            Channel channel = new Channel(host, port, ChannelCredentials.Insecure);
            Client = clientBuilder(channel);
        }
    }
}
