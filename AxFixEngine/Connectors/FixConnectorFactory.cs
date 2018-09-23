using System;
using AxCommonLogger;
using AxCommonLogger.Interfaces;
using QuickFix;

namespace AxFixEngine.Connectors
{
    public class FixConnectorFactory : IFixConnectorFactory
    {
        protected static ILoggerFacade Log = LoggerFacadeProvider.GetDeclaringTypeLogger();

        public IFixConnector CreateConnector(IApplication fixApplication, SessionSettings fixSettings)
        {
            switch (fixSettings.Get().GetString("ConnectionType"))
            {
                case "acceptor": return CreateAcceptor(fixApplication, fixSettings);
                case "initiator": return CreateInitiator(fixApplication, fixSettings);
            }

            return null;
        }

        protected IFixConnector CreateAcceptor(IApplication fixApplication, SessionSettings fixSettings)
        {
            Log.Info("Building acceptor");
            return Create(fixApplication, fixSettings, (app, store, log, settings) => new FixAcceptor(app, store, log, settings));
        }

        protected IFixConnector CreateInitiator(IApplication fixApplication, SessionSettings fixSettings)
        {
            Log.Info("Building initiator");
            return Create(fixApplication, fixSettings, (app, store, log, settings) => new FixInitiator(app, store, log, settings));
        }

        protected IFixConnector Create(IApplication fixApplication,
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
