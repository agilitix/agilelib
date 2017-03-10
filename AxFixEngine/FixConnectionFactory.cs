using System;
using System.Reflection;
using AxFixEngine.Interfaces;
using log4net;
using QuickFix;

namespace AxFixEngine
{
    public class FixConnectionFactory : IFixConnectionFactory
    {
        protected static readonly log4net.ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IFixConnection CreateAcceptor(IFixApplication fixApplication, string acceptorConfigFile)
        {
            Log.InfoFormat("Building acceptor from config file={0}", acceptorConfigFile);
            return Create(fixApplication, acceptorConfigFile, (app, store, log, settings) => new FixAcceptor(app, store, log, settings));
        }

        public IFixConnection CreateInitiator(IFixApplication fixApplication, string initiatorConfigFile)
        {
            Log.InfoFormat("Building initiator from config file={0}", initiatorConfigFile);
            return Create(fixApplication, initiatorConfigFile, (app, store, log, settings) => new FixInitiator(app, store, log, settings));
        }

        private IFixConnection Create(IFixApplication fixApplication,
                                      string initiatorConfigFile,
                                      Func<IFixApplication, IMessageStoreFactory, ILogFactory, SessionSettings, IFixConnection> builder)
        {
            SessionSettings settings = new SessionSettings(initiatorConfigFile);
            IMessageStoreFactory messageStoreFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            IFixConnection fixConnection = builder(fixApplication, messageStoreFactory, logFactory, settings);
            return fixConnection;
        }
    }
}
