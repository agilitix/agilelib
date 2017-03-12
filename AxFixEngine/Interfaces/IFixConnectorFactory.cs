using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixConnectorFactory
    {
        IFixConnector CreateAcceptor(IFixApplication fixApplication, SessionSettings fixSettings);
        IFixConnector CreateInitiator(IFixApplication fixApplication, SessionSettings fixSettings);
    }
}
