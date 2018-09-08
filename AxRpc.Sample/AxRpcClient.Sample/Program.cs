using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using HelloWorld;

namespace AxRpcClient.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            IRpcClient<Greeter.GreeterClient> client = new RpcClient<Greeter.GreeterClient>("127.0.0.1", 5060, channel => new Greeter.GreeterClient(channel));

            AsyncUnaryCall<HelloReply> reply = client.Client.SayHelloAsync(new HelloRequest() {Name = "Toto"});
            Console.WriteLine(reply.ResponseAsync.Result.Message);

            Console.ReadLine();
        }
    }
}
