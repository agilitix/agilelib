using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AxCommonLogger.Facades;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger.Factories
{
    public class Log4netLoggerFacadeFactory : LoggerFacadeFactoryBase
    {
        public override void Configure(string loggerConfigurationFile)
        {
            if (!File.Exists(loggerConfigurationFile))
            {
                throw new FileNotFoundException(nameof(loggerConfigurationFile), loggerConfigurationFile);
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(loggerConfigurationFile));
        }

        public override ILoggerFacade GetLogger(string loggerName)
        {
            Type declaringType = GetDeclaringType();
            return new Log4netLoggerFacade(log4net.LogManager.GetLogger(declaringType.Assembly, loggerName));
        }

        public override ILoggerFacade GetLogger<T>()
        {
            Type type = typeof(T);
            return new Log4netLoggerFacade(log4net.LogManager.GetLogger(type.Assembly, type));
        }

        public override ILoggerFacade GetDeclaringTypeLogger()
        {
            Type declaringType = GetDeclaringType();
            return new Log4netLoggerFacade(log4net.LogManager.GetLogger(declaringType.Assembly, declaringType));
        }
    }
}
