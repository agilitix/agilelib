using System;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger
{
    public class Log4netFacade<T> : ILoggerFacade
    {
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(T));

        public void Configure(string loggerConfigurationFile)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(loggerConfigurationFile));
        }

        public void Debug(Func<string> action)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(action());
            }
        }

        public void Info(Func<string> action)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Info(action());
            }
        }

        public void Warn(Func<string> action)
        {
            if (_logger.IsWarnEnabled)
            {
                _logger.Warn(action());
            }
        }

        public void Error(Func<string> action)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(action());
            }
        }

        public void Fatal(Func<string> action)
        {
            if (_logger.IsFatalEnabled)
            {
                _logger.Fatal(action());
            }
        }

        public void Debug(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(message);
            }
        }

        public void Info(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Info(message);
            }
        }

        public void Warn(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Warn(message);
            }
        }

        public void Error(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Error(message);
            }
        }

        public void Fatal(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Fatal(message);
            }
        }
    }
}
