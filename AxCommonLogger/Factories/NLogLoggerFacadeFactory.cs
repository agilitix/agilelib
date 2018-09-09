using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AxCommonLogger.Facades;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger.Factories
{
    public class NLogLoggerFacadeFactory : LoggerFacadeFactoryBase
    {
        public override void Configure(string loggerConfigurationFile)
        {
            if (!File.Exists(loggerConfigurationFile))
            {
                throw new FileNotFoundException(nameof(loggerConfigurationFile), loggerConfigurationFile);
            }

            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(loggerConfigurationFile);
        }

        public override ILoggerFacade GetLogger<T>()
        {
            Type type = typeof(T);
            return new NLogLoggerFacade(NLog.LogManager.GetCurrentClassLogger(type));
        }

        public override ILoggerFacade GetLogger(string loggerName)
        {
            return new NLogLoggerFacade(NLog.LogManager.GetLogger(loggerName));
        }

        public override ILoggerFacade GetDeclaringTypeLogger()
        {
            Type declaringType = GetDeclaringType();
            return new NLogLoggerFacade(NLog.LogManager.GetCurrentClassLogger(declaringType));
        }
    }
}
