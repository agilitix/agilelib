namespace AxCommonLogger.Interfaces
{
    public interface ILoggerFacadeFactory
    {
        void Configure(string loggerConfigurationFile);

        ILoggerFacade GetLogger<T>();
        ILoggerFacade GetLogger(string loggerName);
        ILoggerFacade GetDeclaringTypeLogger();
    }
}
