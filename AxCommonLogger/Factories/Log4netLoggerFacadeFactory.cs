using System;
using System.IO;
using AxCommonLogger.Facades;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger.Factories
{
    public class Log4netLoggerFacadeFactory : ILoggerFacadeFactory
    {
        private static bool _initialized;
        private static readonly NoOpLoggerFacade _noOpLogger = new NoOpLoggerFacade();

        public void Initialize(string loggerConfigurationFile)
        {
            if (!File.Exists(loggerConfigurationFile))
            {
                throw new FileNotFoundException(nameof(loggerConfigurationFile), loggerConfigurationFile);
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(loggerConfigurationFile));
            _initialized = true;
        }

        public ILoggerFacade GetLogger<T>()
        {
            if (_initialized)
            {
                return new Log4netLoggerFacade<T>();
            }

            return _noOpLogger;
        }
    }
}
