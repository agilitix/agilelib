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
        private static readonly NoOpLoggerFacade _noOpLogger = new NoOpLoggerFacade();

        public void Configure(string loggerConfigurationFile)
        {
            if (!File.Exists(loggerConfigurationFile))
            {
                throw new FileNotFoundException(nameof(loggerConfigurationFile), loggerConfigurationFile);
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(loggerConfigurationFile));

            _initialized = true;
        }

        public ILoggerFacade GetLogger(string loggerName)
        {
            Type declaringType = GetDeclaringType();

            return _initialized && declaringType != null
                       ? (ILoggerFacade) new Log4netLoggerFacade(log4net.LogManager.GetLogger(declaringType.Assembly, loggerName))
                       : _noOpLogger;
        }

        public ILoggerFacade GetLogger<T>()
        {
            Type type = typeof(T);

            return _initialized
                       ? (ILoggerFacade) new Log4netLoggerFacade(log4net.LogManager.GetLogger(type.Assembly, type))
                       : _noOpLogger;
        }

        public ILoggerFacade GetDeclaringTypeLogger()
        {
            Type declaringType = GetDeclaringType();

            return _initialized && declaringType != null
                       ? (ILoggerFacade) new Log4netLoggerFacade(log4net.LogManager.GetLogger(declaringType.Assembly, declaringType))
                       : _noOpLogger;
        }

        protected Type GetDeclaringType()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type declaringType = null;

            StackTrace stackTrace = new StackTrace();
            for (int i = 0; i < stackTrace.FrameCount; ++i)
            {
                StackFrame frame = new StackFrame(i, false);
                MethodBase method = frame.GetMethod();
                declaringType = method.DeclaringType;
                if (declaringType?.Assembly != executingAssembly)
                {
                    break;
                }
            }

            return declaringType;
        }
    }
}
