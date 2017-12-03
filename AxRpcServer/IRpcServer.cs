namespace AxRpcServer
{
    public interface IRpcServer
    {
        string Host { get; }
        int Port { get; }

        void Start();
        void Stop();
    }
}
