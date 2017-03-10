
namespace AxFixEngine.Interfaces
{
    public interface IFixConnectionFactory
    {
        IFixConnection CreateAcceptor(IFixApplication fixApplication, string acceptorConfigFile);
        IFixConnection CreateInitiator(IFixApplication fixApplication, string initiatorConfigFile);
    }
}
