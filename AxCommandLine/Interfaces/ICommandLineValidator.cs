namespace AxCommandLine.Interfaces
{
    public interface ICommandLineValidator
    {
        void AddOption(ICommandLineOption option);
        bool Validate();

        string Usage { get; }
    }
}
