using QuickFix;

namespace AxFixEngine.Connectors
{
    public interface IFixConnectorFactory
    {
        IFixConnector CreateConnector(IApplication fixApplication, SessionSettings fixSettings);
    }
}
