﻿using System;
using System.Reflection;
using AxFixEngine.Interfaces;
using log4net;
using QuickFix;

namespace AxFixEngine
{
    public class FixConnectorFactory : IFixConnectorFactory
    {
        protected static readonly log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IFixConnector CreateAcceptor(IApplication fixApplication, SessionSettings fixSettings)
        {
            Log.InfoFormat("Building acceptor");
            return Create(fixApplication, fixSettings, (app, store, log, settings) => new FixAcceptor(app, store, log, settings));
        }

        public IFixConnector CreateInitiator(IApplication fixApplication, SessionSettings fixSettings)
        {
            Log.InfoFormat("Building initiator");
            return Create(fixApplication, fixSettings, (app, store, log, settings) => new FixInitiator(app, store, log, settings));
        }

        private IFixConnector Create(IApplication fixApplication,
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
