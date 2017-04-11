using System;
using System.Diagnostics;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger.Facades
{
    public class Log4netLoggerFacade : ILoggerFacade
    {
        protected readonly log4net.ILog _logger;

        public bool IsDebugEnabled => _logger.IsDebugEnabled;
        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsWarnEnabled => _logger.IsWarnEnabled;
        public bool IsErrorEnabled => _logger.IsErrorEnabled;
        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        public Log4netLoggerFacade(log4net.ILog logger)
        {
            _logger = logger;
        }

        [DebuggerStepThrough]
        public void Debug(string message)
        {
            if (IsDebugEnabled)
            {
                _logger.Debug(message);
            }
        }

        [DebuggerStepThrough]
        public void Info(string message)
        {
            if (IsInfoEnabled)
            {
                _logger.Info(message);
            }
        }

        [DebuggerStepThrough]
        public void Warn(string message)
        {
            if (IsWarnEnabled)
            {
                _logger.Warn(message);
            }
        }

        [DebuggerStepThrough]
        public void Error(string message)
        {
            if (IsErrorEnabled)
            {
                _logger.Error(message);
            }
        }

        [DebuggerStepThrough]
        public void Fatal(string message)
        {
            if (IsFatalEnabled)
            {
                _logger.Fatal(message);
            }
        }

        [DebuggerStepThrough]
        public void DebugFormat(string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                _logger.DebugFormat(format, args);
            }
        }

        [DebuggerStepThrough]
        public void InfoFormat(string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                _logger.InfoFormat(format, args);
            }
        }

        [DebuggerStepThrough]
        public void WarnFormat(string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                _logger.WarnFormat(format, args);
            }
        }

        [DebuggerStepThrough]
        public void ErrorFormat(string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                _logger.ErrorFormat(format, args);
            }
        }

        [DebuggerStepThrough]
        public void FatalFormat(string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                _logger.FatalFormat(format, args);
            }
        }

        [DebuggerStepThrough]
        public void Debug(string message, Exception exception)
        {
            if (IsDebugEnabled)
            {
                _logger.Debug(message, exception);
            }
        }

        [DebuggerStepThrough]
        public void Info(string message, Exception exception)
        {
            if (IsInfoEnabled)
            {
                _logger.Info(message, exception);
            }
        }

        [DebuggerStepThrough]
        public void Warn(string message, Exception exception)
        {
            if (IsWarnEnabled)
            {
                _logger.Warn(message, exception);
            }
        }

        [DebuggerStepThrough]
        public void Error(string message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                _logger.Error(message, exception);
            }
        }

        [DebuggerStepThrough]
        public void Fatal(string message, Exception exception)
        {
            if (IsFatalEnabled)
            {
                _logger.Fatal(message, exception);
            }
        }

        [DebuggerStepThrough]
        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                _logger.DebugFormat(formatProvider, format, args);
            }
        }

        [DebuggerStepThrough]
        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                _logger.InfoFormat(formatProvider, format, args);
            }
        }

        [DebuggerStepThrough]
        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                _logger.WarnFormat(formatProvider, format, args);
            }
        }

        [DebuggerStepThrough]
        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                _logger.ErrorFormat(formatProvider, format, args);
            }
        }

        [DebuggerStepThrough]
        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                _logger.FatalFormat(formatProvider, format, args);
            }
        }
    }
}
