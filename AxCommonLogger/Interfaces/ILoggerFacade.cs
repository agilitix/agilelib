using System;

namespace AxCommonLogger.Interfaces
{
    public interface ILoggerFacade
    {
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }

        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);

        void DebugFormat(string format, params object[] args);
        void InfoFormat(string format, params object[] args);
        void WarnFormat(string format, params object[] args);
        void ErrorFormat(string format, params object[] args);
        void FatalFormat(string format, params object[] args);

        void DebugFormat(IFormatProvider formatProvider, string format, params object[] args);
        void InfoFormat(IFormatProvider formatProvider, string format, params object[] args);
        void WarnFormat(IFormatProvider formatProvider, string format, params object[] args);
        void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args);
        void FatalFormat(IFormatProvider formatProvider, string format, params object[] args);

        void Debug(string message, Exception exception);
        void Info(string message, Exception exception);
        void Warn(string message, Exception exception);
        void Error(string message, Exception exception);
        void Fatal(string message, Exception exception);

        void Configure(string loggerConfigurationFile);
    }
}
