using Grpc.Core;

namespace AxRpcServer
{
    public interface IRpcService
    {
        ServerServiceDefinition BindService();
    }
}
