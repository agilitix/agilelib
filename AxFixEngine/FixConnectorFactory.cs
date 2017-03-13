using System;
using AxCommonLogger;
using AxCommonLogger.Interfaces;
using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine
{
    public class FixConnectorFactory : IFixConnectorFactory
    {
        protected static ILoggerFacade Log = new Log4netFacade<FixConnectorFactory>();

        public IFixConnector CreateAcceptor(IApplication fixApplication, SessionSettings fixSettings)
        {
            Log.Info("Building acceptor");
            return Create(fixApplication, fixSettings, (app, store, log, settings) => new FixAcceptor(app, store, log, settings));
        }

        public IFixConnector CreateInitiator(IApplication fixApplication, SessionSettings fixSettings)
        {
            Log.Info("Building initiator");
            return Create(fixApplication, fixSettings, (app, store, log, settings) => new FixInitiator(app, store, log, settings));
        }

        private static IFixConnector Create(IApplication fixApplication,
                                            SessionSettings fixSettings,
                                            Func<IApplication, IMessageStoreFactory, ILogFactory, SessionSettings, IFixConnector> builder)
        {
            IMessageStoreFactory messageStoreFactory = new FileStoreFactory(fixSettings);
            ILogFactory logFactory = new FileLogFactory(fixSettings);
            IFixConnector connector = builder(fixApplication, messageStoreFactory, logFactory, fixSettings);
            return connector;
        }
    }
}
