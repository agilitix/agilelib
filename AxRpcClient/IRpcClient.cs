namespace AxRpcClient
{
    public interface IRpcClient<out T>
    {
        T Client { get; }
    }
}
