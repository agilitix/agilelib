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

        public static ILoggerFacade GetLogger<T>()
        {
            return _LoggerFacadeFactory.GetLogger<T>();
        }
    }
}
