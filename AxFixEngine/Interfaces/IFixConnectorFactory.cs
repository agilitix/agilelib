using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixConnectorFactory
    {
        IFixConnector CreateAcceptor(IApplication fixApplication, SessionSettings fixSettings);
        IFixConnector CreateInitiator(IApplication fixApplication, SessionSettings fixSettings);
    }
}
