using System;

namespace AxCommonLogger.Interfaces
{
    public interface ILoggerFacade
    {
        void Configure(string loggerConfigurationFile);

        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);

        void Debug(Func<string> action);
        void Info(Func<string> action);
        void Warn(Func<string> action);
        void Error(Func<string> action);
        void Fatal(Func<string> action);
    }
}
