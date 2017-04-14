using System;
using System.Diagnostics;
using System.Reflection;
using AxCommonLogger.Interfaces;

namespace AxCommonLogger
{
    public static class LoggerFacadeProvider
    {
        private static ILoggerFacadeFactory _LoggerFacadeFactory;

        public static void Initialize(ILoggerFacadeFactory loggerFacadeFactory)
        {
            _LoggerFacadeFactory = loggerFacadeFactory;
        }

        public static ILoggerFacade GetLogger(string loggerName)
        {
            return _LoggerFacadeFactory.GetLogger(loggerName);
        }

        public static ILoggerFacade GetLogger<T>()
        {
            return _LoggerFacadeFactory.GetLogger<T>();
        }

        public static ILoggerFacade GetDeclaringTypeLogger()
        {
            return _LoggerFacadeFactory.GetDeclaringTypeLogger();
        }
    }
}
