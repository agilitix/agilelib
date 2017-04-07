namespace AxCommonLogger.Interfaces
{
    public interface ILoggerFacadeFactory
    {
        void Initialize(string loggerConfigurationFile);
        ILoggerFacade GetLogger<T>();
    }
}
