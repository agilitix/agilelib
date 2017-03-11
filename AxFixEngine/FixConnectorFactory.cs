using System;
using System.Reflection;
using AxFixEngine.Interfaces;
using log4net;
using QuickFix;

namespace AxFixEngine
{
    public class FixConnectorFactory : IFixConnectorFactory
    {
        protected static readonly log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IFixConnector CreateAcceptor(IFixApplication fixApplication, IFixSettings fixSettings)
        {
            Log.InfoFormat("Building acceptor");
            return Create(fixApplication, fixSettings, (app, store, log, settings) => new FixAcceptor(app, store, log, settings));
        }

        public IFixConnector CreateInitiator(IFixApplication fixApplication, IFixSettings fixSettings)
        {
            Log.InfoFormat("Building initiator");
            return Create(fixApplication, fixSettings, (app, store, log, settings) => new FixInitiator(app, store, log, settings));
        }

        private IFixConnector Create(IFixApplication fixApplication,
                                      IFixSettings fixSettings,
                                      Func<IFixApplication, IMessageStoreFactory, ILogFactory, SessionSettings, IFixConnector> builder)
        {
            SessionSettings sessionSettings = fixSettings.GetSessionSettings();
            IMessageStoreFactory messageStoreFactory = new FileStoreFactory(sessionSettings);
            ILogFactory logFactory = new FileLogFactory(sessionSettings);
            IFixConnector connector = builder(fixApplication, messageStoreFactory, logFactory, sessionSettings);
            return connector;
        }
    }
}
