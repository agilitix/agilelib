using AxCommonLogger;
using AxCommonLogger.Interfaces;
using QuickFix;
using QuickFix.Transport;

namespace AxFixEngine.Connectors
{
    class FixInitiator : IFixConnector
    {
        protected static ILoggerFacade Log = LoggerFacadeProvider.GetDeclaringTypeLogger();
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
            Log.Info("Starting initiator");
            _initiator.Start();
        }

        public void Stop()
        {
            Log.Info("Stopping initiator");
            _initiator.Stop();
        }
    }
}
