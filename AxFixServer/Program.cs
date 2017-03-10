using System;
using System.Reflection;
using AxCommandLine;
using AxCommandLine.Interfaces;
using AxConfiguration;
using AxConfiguration.Interfaces;
using AxFixEngine;
using AxFixEngine.Interfaces;
using AxUtils;
using log4net;
using Microsoft.Practices.Unity;
using ILog = log4net.ILog;

namespace AxFixServer
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            const string configfile = @".\Configuration\fixengine.config";

            IAppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Load(configfile);

            string log4netConfigFile;
            if (!appConfiguration.TryGetSetting("log4net", out log4netConfigFile))
            {
                Console.WriteLine("Cannot get key 'log4net' from config file=" + configfile);
                Console.ReadLine();
                return;
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4netConfigFile));

            Log.Info("Starting FIX engine version=" + Assembly.GetEntryAssembly().GetName().Version);

            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);
            Log.Info("Command line arguments: " + commandLineArguments);

            Log.Info("Loading unity container");
            IUnityContainer unity = new UnityContainer();
            unity.Load(appConfiguration);

            IFixConnectionFactory fixConnectionFactory = new FixConnectionFactory();
            IFixConnection acceptor = null;
            IFixConnection initiator = null;

            bool acceptorEnabled = appConfiguration.GetSetting<bool>("acceptor_enabled");
            Log.Info("Acceptor enabled=" + acceptorEnabled);
            if (acceptorEnabled)
            {
                string connectorConfigFile = appConfiguration.GetSetting<string>("acceptor_settings");
                acceptor = BuildFixConnector(connectorConfigFile, (fixapp, cfgfile) => fixConnectionFactory.CreateAcceptor(fixapp, cfgfile));
            }

            bool initiatorEnabled = appConfiguration.GetSetting<bool>("initiator_enabled");
            Log.Info("Initiator enabled=" + initiatorEnabled);
            if (initiatorEnabled)
            {
                string connectorConfigFile = appConfiguration.GetSetting<string>("initiator_settings");
                initiator = BuildFixConnector(connectorConfigFile, (fixapp, cfgfile) => fixConnectionFactory.CreateInitiator(fixapp, cfgfile));
            }

            acceptor?.Start();
            initiator?.Start();

            Console.WriteLine();
            Console.ReadLine();

            acceptor?.Stop();
            initiator?.Stop();
        }

        private static IFixConnection BuildFixConnector(string connectorConfigFile, Func<IFixApplication, string, IFixConnection> builder)
        {
            IniFileReader inifile = new IniFileReader(connectorConfigFile);
            string messageHistoryFile = inifile.GetSetting<string>("APPLICATION", "MessagesHistoryFile");

            IFixMessageHistory messageHistory = new FixMessageFileHistory(messageHistoryFile);
            IFixMessageHandler messageHandler = new FixMessageHandler();
            IFixApplication fixApp = new FixApplication(messageHandler, messageHistory);

            return builder(fixApp, connectorConfigFile);
        }
    }
}
