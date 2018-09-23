using System;
using System.Collections.Generic;
using System.Reflection;
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
            _dialects = new FixDialects();
            _connectorFactory = new FixConnectorFactory();
            _sessions = new List<SessionID>();
            _handlers = new FixMessageHandlers();
            _configFile = fixIniFileConfig;

            if (!string.IsNullOrWhiteSpace(_configFile))
            {
                _sessionSettings = new SessionSettings(_configFile);

                if (_sessionSettings.Get().GetString("ConnectionType") != "acceptor"
                    && _sessionSettings.Get().GetString("ConnectionType") != "initiator")
                {
                    throw new ConfigError("The config file is not valid for either an acceptor or initiator");
                }

                _dialects.AddSessionSettings(_sessionSettings);

                foreach (SessionID sessionId in _sessionSettings.GetSessions())
                {
                    _sessions.Add(sessionId);

                    Dictionary sessionConf = _sessionSettings.Get(sessionId);

                    // Create message handler for this session.
                    string typeName = sessionConf.GetString("MessageHandler");
                    Type handlerType = Type.GetType(typeName);
                    IFixMessageHandler handler = Activator.CreateInstance(handlerType) as IFixMessageHandler;
                    _handlers.SetMessageHandler(sessionId, handler);
                }
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
