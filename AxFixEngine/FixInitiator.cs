using System.Reflection;
using AxFixEngine.Interfaces;
using log4net;
using QuickFix;
using QuickFix.Transport;

namespace AxFixEngine
{
    class FixInitiator : IFixConnection
    {
        protected static readonly log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
