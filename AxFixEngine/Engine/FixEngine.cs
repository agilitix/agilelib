using System;
using System.Collections.Generic;
using System.IO;
using AxCommonLogger;
using AxCommonLogger.Interfaces;
using AxFixEngine.Connectors;
using AxFixEngine.Dialects;
using AxFixEngine.Handlers;
using QuickFix;

namespace AxFixEngine.Engine
{
    public class FixEngine : IFixEngine
    {
        protected ILoggerFacade Logger = LoggerFacadeProvider.GetDeclaringTypeLogger();
        protected IFixConnector _connector;
        protected readonly IList<SessionID> _sessions;
        protected readonly IFixConnectorFactory _connectorFactory;
        protected readonly SessionSettings _sessionSettings;
        protected readonly IFixDialects _dialects;
        protected readonly IFixMessageHandlers _handlers;
        protected readonly string _configFile;

        public string ConfigFile => _configFile;
        public IList<SessionID> Sessions => _sessions;
        public IFixDialects Dialects => _dialects;
        public IFixMessageHandlers Handlers => _handlers;

        public FixEngine(string fixIniFileConfig)
        {
            // Should be injected.
            _dialects = new FixDialects();
            _connectorFactory = new FixConnectorFactory();
            _sessions = new List<SessionID>();
            _handlers = new FixMessageHandlers();

            _configFile = fixIniFileConfig;

            if (!string.IsNullOrWhiteSpace(_configFile) && File.Exists(_configFile))
            {
                Logger.InfoFormat("Building FIX engine with config file={0}", fixIniFileConfig);

                _sessionSettings = new SessionSettings(_configFile);

                string connectionType = _sessionSettings.Get().GetString("ConnectionType");
                if (connectionType != "acceptor" && connectionType != "initiator")
                {
                    throw new ConfigError("The config file is not valid for either acceptor or initiator type");
                }

                Logger.InfoFormat("The FIX engine is an '{0}'", connectionType);

                _dialects.AddSessionSettings(_sessionSettings);

                foreach (SessionID sessionId in _sessionSettings.GetSessions())
                {
                    _sessions.Add(sessionId);

                    Dictionary sessionConf = _sessionSettings.Get(sessionId);

                    // The fix message handler must be declared in the initiator/acceptor ini file like :
                    // ......
                    // [SESSION]
                    // MessageHandlerType="AxFixApp.Fix44MessageCracker, AxFixApp"
                    // .....
                    string typeName = sessionConf.GetString("MessageHandlerType").Trim('"').Trim(); // Remove quotes and white spaces.
                    Type handlerType = Type.GetType(typeName);
                    if (handlerType == null)
                    {
                        throw new ConfigError("The config file=" + _configFile + " must define a message handler type (ie: MessageHandlerType=\"MyNamespace.MyMessageHandler, MyAssembly\"");
                    }

                    // Instantiate the handler for each session, it can be the same for all.
                    IFixMessageHandler handler = Activator.CreateInstance(handlerType) as IFixMessageHandler;
                    _handlers.SetMessageHandler(sessionId, handler);

                    Logger.InfoFormat("Set session={0} with handler={1}", sessionId, handlerType);
                }
            }
            else
            {
                Logger.InfoFormat("Invalid fix config file={0}, the requested fix engine is not created.", _configFile);
            }
        }

        public void CreateApplication()
        {
            if (_sessionSettings != null)
            {
                IApplication fixApp = new FixApplication(_dialects, _handlers);
                _connector = _connectorFactory.CreateConnector(fixApp, _sessionSettings);
            }
        }

        public void Start()
        {
            _connector?.Start();
        }

        public void Stop()
        {
            _connector?.Stop();
        }
    }
}
