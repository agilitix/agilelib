namespace AxConfiguration.UnitTests.Test.Logger.Interfaces
{
    public interface ILogger
    {
        string LoggerName { get; }

        void Log(string message);
    }
}