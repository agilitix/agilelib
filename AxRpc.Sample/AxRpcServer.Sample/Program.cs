using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using HelloWorld;

namespace AxRpcServer.Sample
{
    public class Service : Greeter.GreeterBase, IRpcService
    {
        public ServerServiceDefinition BindService()
        {
            return Greeter.BindService(this);
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply
                               {
                                   Message = "Hello " + request.Name + "!!",
                               };
            return Task.FromResult(reply);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IRpcServer server = new RpcServer("127.0.0.1",
                                              5060,
                                              new IRpcService[]
                                              {
                                                  new Service()
                                              });

            server.Start();
            Console.ReadLine();
            server.Stop();
        }
    }
}
