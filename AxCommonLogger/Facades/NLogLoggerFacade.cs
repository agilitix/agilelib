using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger.Facades
{
    internal class NLogLoggerFacade : ILoggerFacade
    {
        protected NLog.ILogger _logger;

        public bool IsDebugEnabled => _logger.IsDebugEnabled;
        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsWarnEnabled => _logger.IsWarnEnabled;
        public bool IsErrorEnabled => _logger.IsErrorEnabled;
        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        public NLogLoggerFacade(NLog.ILogger logger)
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
                _logger.Debug(format, args);
            }
        }

        [DebuggerStepThrough]
        public void InfoFormat(string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                _logger.Info(format, args);
            }
        }

        [DebuggerStepThrough]
        public void WarnFormat(string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                _logger.Warn(format, args);
            }
        }

        [DebuggerStepThrough]
        public void ErrorFormat(string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                _logger.Error(format, args);
            }
        }

        [DebuggerStepThrough]
        public void FatalFormat(string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                _logger.Fatal(format, args);
            }
        }

        [DebuggerStepThrough]
        public void Debug(string message, Exception exception)
        {
            if (IsDebugEnabled)
            {
                _logger.Debug(exception, message);
            }
        }

        [DebuggerStepThrough]
        public void Info(string message, Exception exception)
        {
            if (IsInfoEnabled)
            {
                _logger.Info(exception, message);
            }
        }

        [DebuggerStepThrough]
        public void Warn(string message, Exception exception)
        {
            if (IsWarnEnabled)
            {
                _logger.Warn(exception, message);
            }
        }

        [DebuggerStepThrough]
        public void Error(string message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                _logger.Error(exception, message);
            }
        }

        [DebuggerStepThrough]
        public void Fatal(string message, Exception exception)
        {
            if (IsFatalEnabled)
            {
                _logger.Fatal(exception, message);
            }
        }

        [DebuggerStepThrough]
        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                _logger.Debug(formatProvider, format, args);
            }
        }

        [DebuggerStepThrough]
        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                _logger.Info(formatProvider, format, args);
            }
        }

        [DebuggerStepThrough]
        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                _logger.Warn(formatProvider, format, args);
            }
        }

        [DebuggerStepThrough]
        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                _logger.Error(formatProvider, format, args);
            }
        }

        [DebuggerStepThrough]
        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                _logger.Fatal(formatProvider, format, args);
            }
        }
    }
}
