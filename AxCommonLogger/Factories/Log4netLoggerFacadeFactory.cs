using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AxCommonLogger.Facades;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger.Factories
{
    public class Log4netLoggerFacadeFactory : ILoggerFacadeFactory
    {
        private static bool _initialized;
        private static ILoggerFacade _defaultLogger;

        public void Configure(string loggerConfigurationFile)
        {
            if (!File.Exists(loggerConfigurationFile))
            {
                throw new FileNotFoundException(nameof(loggerConfigurationFile), loggerConfigurationFile);
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(loggerConfigurationFile));

            Type declaringType = GetDeclaringType();
            _defaultLogger = new Log4netLoggerFacade(log4net.LogManager.GetLogger(declaringType.Assembly, declaringType));

            _initialized = true;
        }

        public ILoggerFacade GetLogger(string loggerName)
        {
            Type declaringType = GetDeclaringType();
            return _initialized
                       ? new Log4netLoggerFacade(log4net.LogManager.GetLogger(declaringType.Assembly, loggerName))
                       : _defaultLogger;
        }

        public ILoggerFacade GetLogger<T>()
        {
            Type type = typeof(T);
            return _initialized
                       ? new Log4netLoggerFacade(log4net.LogManager.GetLogger(type.Assembly, type))
                       : _defaultLogger;
        }

        public ILoggerFacade GetDeclaringTypeLogger()
        {
            Type declaringType = GetDeclaringType();
            return _initialized
                       ? new Log4netLoggerFacade(log4net.LogManager.GetLogger(declaringType.Assembly, declaringType))
                       : _defaultLogger;
        }

        protected Type GetDeclaringType()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            Type declaringType = null;

            StackTrace stackTrace = new StackTrace();
            for (int i = 2; i < stackTrace.FrameCount; ++i)
            {
                var frame = new StackFrame(i, false);
                declaringType = frame.GetMethod().DeclaringType;
                if (declaringType?.Assembly != thisAssembly)
                {
                    break;
                }
            }

            return declaringType ?? GetType();
        }
    }
}
