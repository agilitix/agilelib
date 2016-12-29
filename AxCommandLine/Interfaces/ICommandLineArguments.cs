
namespace AxCommandLine.Interfaces
{
    public interface ICommandLineArguments
    {
        int Count();
        bool Contains(string argument);

        void Set(string argument, string value);
        T Get<T>(string argument);
        bool TryGet<T>(string argument, out T output);
    }
}
