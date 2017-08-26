using QuickFix;

namespace AxFixEngine.Connectors
{
    public interface IFixConnectorFactory
    {
        IFixConnector CreateAcceptor(IApplication fixApplication, SessionSettings fixSettings);
        IFixConnector CreateInitiator(IApplication fixApplication, SessionSettings fixSettings);
    }
}
