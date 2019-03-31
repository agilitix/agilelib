namespace AxFixEngine.Engine
{
    public interface IFixEngineManager
    {
        void CreateFixEngine(string fixConfig);

        void Start();
        void Stop();
    }
}
