
namespace AxCommandLine.Interfaces
{
    public interface ICommandLineArguments
    {
        int Count();
        bool Contains(string argument);

        void Set<T>(string argument, T value);
        T Get<T>(string argument);
        bool TryGet<T>(string argument, out T output);
    }
}
