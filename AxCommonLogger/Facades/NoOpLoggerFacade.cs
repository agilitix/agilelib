using System;
using System.Diagnostics;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger.Facades
{
    public class NoOpLoggerFacade : ILoggerFacade
    {
        public bool IsDebugEnabled => false;
        public bool IsInfoEnabled => false;
        public bool IsWarnEnabled => false;
        public bool IsErrorEnabled => false;
        public bool IsFatalEnabled => false;

        [DebuggerStepThrough]
        public void Debug(string message)
        {
        }

        [DebuggerStepThrough]
        public void Info(string message)
        {
        }

        [DebuggerStepThrough]
        public void Warn(string message)
        {
        }

        [DebuggerStepThrough]
        public void Error(string message)
        {
        }

        [DebuggerStepThrough]
        public void Fatal(string message)
        {
        }

        [DebuggerStepThrough]
        public void DebugFormat(string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void InfoFormat(string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void WarnFormat(string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void ErrorFormat(string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void FatalFormat(string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void Debug(string message, Exception exception)
        {
        }

        [DebuggerStepThrough]
        public void Info(string message, Exception exception)
        {
        }

        [DebuggerStepThrough]
        public void Warn(string message, Exception exception)
        {
        }

        [DebuggerStepThrough]
        public void Error(string message, Exception exception)
        {
        }

        [DebuggerStepThrough]
        public void Fatal(string message, Exception exception)
        {
        }

        [DebuggerStepThrough]
        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
        }

        [DebuggerStepThrough]
        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
        }
    }
}
