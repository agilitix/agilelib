using System.Reflection;
using AxFixEngine.Interfaces;
using log4net;
using QuickFix;

namespace AxFixEngine
{
    public class FixAcceptor : IFixConnector
    {
        protected static readonly log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAcceptor _acceptor;

        public FixAcceptor(IApplication application,
                           IMessageStoreFactory messageStoreFactory,
                           ILogFactory logFactory,
                           SessionSettings settings)
        {
            _acceptor = new ThreadedSocketAcceptor(application, messageStoreFactory, settings, logFactory);
        }

        public void Start()
        {
            Log.Info("Starting acceptor");
            _acceptor.Start();
        }

        public void Stop()
        {
            Log.Info("Stopping acceptor");
            _acceptor.Stop();
        }
    }
}
