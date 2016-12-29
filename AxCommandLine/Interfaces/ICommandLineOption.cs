
namespace AxCommandLine.Interfaces
{
    public interface ICommandLineOption
    {
        string Name { get; }
        bool Required { get; }
        string HelpText { get; }
    }
}
