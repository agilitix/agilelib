using AxFixEngine.Interfaces;
using QuickFix;
using QuickFix.Transport;

namespace AxFixEngine
{
    class FixInitiator : IFixConnection
    {
        private readonly IInitiator _initiator;

        public FixInitiator(IApplication application,
                            IMessageStoreFactory messageStoreFactory,
                            ILogFactory logFactory,
                            SessionSettings sessionSettings)
        {
            _initiator = new SocketInitiator(application, messageStoreFactory, sessionSettings, logFactory);
        }

        public void Start()
        {
            _initiator.Start();
        }

        public void Stop()
        {
            _initiator.Stop();
        }
    }
}
