using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine
{
    public class FixAcceptor : IFixConnection
    {
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
            _acceptor.Start();
        }

        public void Stop()
        {
            _acceptor.Stop();
        }
    }
}
