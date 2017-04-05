using System;
using System.IO;
using AxCommonLogger.Facades;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger
{
    public static class LoggerFacadeProvider
    {
        private static readonly NoOpLoggerFacade _noOpLogger = new NoOpLoggerFacade();
        private static LoggerType _loggerType;

        public enum LoggerType
        {
            Log4net,
        }

        public static void Initialize(LoggerType loggerType, string loggerConfigFile)
        {
            if (!File.Exists(loggerConfigFile))
            {
                throw new FileNotFoundException(nameof(loggerConfigFile), loggerConfigFile);
            }

            _loggerType = loggerType;
            switch (_loggerType)
            {
                case LoggerType.Log4net:
                    log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(loggerConfigFile));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType), loggerType, null);
            }
        }

        public static ILoggerFacade GetLogger<T>()
        {
            switch (_loggerType)
            {
                case LoggerType.Log4net:
                    return new Log4netLoggerFacade<T>();
                default:
                    return _noOpLogger;
            }
        }
    }
}
