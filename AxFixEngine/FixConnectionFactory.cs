using System;
using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine
{
    class FixConnectionFactory : IFixConnectionFactory
    {
        public IFixConnection CreateAcceptor(IFixApplication fixApplication, string acceptorConfigFile)
        {
            return Create(fixApplication, acceptorConfigFile, (app, store, log, settings) => new FixAcceptor(app, store, log, settings));
        }

        public IFixConnection CreateInitiator(IFixApplication fixApplication, string initiatorConfigFile)
        {
            return Create(fixApplication, initiatorConfigFile, (app, store, log, settings) => new FixInitiator(app, store, log, settings));
        }

        private IFixConnection Create(IFixApplication fixApplication,
                                      string initiatorConfigFile,
                                      Func<IFixApplication, IMessageStoreFactory, ILogFactory, SessionSettings, IFixConnection> builder)
        {
            SessionSettings settings = new SessionSettings(initiatorConfigFile);
            IMessageStoreFactory messageStoreFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            IFixConnection initiator = builder(fixApplication, messageStoreFactory, logFactory, settings);
            return initiator;
        }
    }
}
