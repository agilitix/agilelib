using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixConnectorFactory
    {
        IFixConnector CreateAcceptor(IFixApplication fixApplication, IFixSettings fixSettings);
        IFixConnector CreateInitiator(IFixApplication fixApplication, IFixSettings fixSettings);
    }
}
