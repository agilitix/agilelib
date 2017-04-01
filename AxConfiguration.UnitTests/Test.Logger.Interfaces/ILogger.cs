namespace AxConfiguration.UnitTests.Test.Logger.Interfaces
{
    internal interface ILogger
    {
        string LoggerName { get; }

        void Log(string message);
    }
}