using System;
using System.Reflection;
using AxCommandLine;
using AxCommandLine.Interfaces;
using AxCommonLogger;
using AxCommonLogger.Interfaces;
using AxConfiguration;
using AxConfiguration.Interfaces;
using AxFixEngine;
using AxFixEngine.Extensions;
using AxFixEngine.Interfaces;
using AxUtils;
using QuickFix;

namespace AxFixServer
{
    class Program
    {
        protected static ILoggerFacade Log = new Log4netFacade<Program>();
        private static ConsoleExitHandler _consoleExit;

        static Program()
        {
            _consoleExit = new ConsoleExitHandler();
        }

        static void Main(string[] args)
        {
            IAppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.LoadFile(@".\Configuration\main.config");

            string log4NetConfigFile = appConfiguration.Configuration.AppSettings.Settings["log4net"].Value;
            if (string.IsNullOrWhiteSpace(log4NetConfigFile))
            {
                Console.WriteLine("Cannot get key 'log4net' from config file=" + appConfiguration.ConfigurationFile);
                Console.ReadLine();
                return;
            }

            Log.Configure(log4NetConfigFile);

            Log.Info("Starting FIX engine version=" + Assembly.GetEntryAssembly().GetName().Version);

            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);
            Log.Info("Command line arguments: " + commandLineArguments);

            IUnityConfiguration unity = new UnityConfiguration();
            unity.LoadDefaultFile(@".\Configuration");
            Log.Info("Loaded unity configuration from file=" + unity.ConfigurationFile);

            IFixConnectorFactory fixConnectorFactory = new FixConnectorFactory();
            IFixConnector acceptor = null;
            IFixConnector initiator = null;

            string acceptorEnabled = appConfiguration.Configuration.AppSettings.Settings["acceptor_enabled"].Value;
            Log.Info("Acceptor enabled=" + acceptorEnabled);
            if (acceptorEnabled.Equals("true"))
            {
                string acceptorConfigFile = appConfiguration.Configuration.AppSettings.Settings["acceptor_settings"].Value;

                SessionSettings fixSettings = new SessionSettings(acceptorConfigFile);
                IFixDataDictionaries dataDictionaries = new FixDataDictionaries(fixSettings);

                acceptor = BuildFixConnector(fixSettings, (fixapp, settings) => fixConnectorFactory.CreateAcceptor(fixapp, settings));
            }

            string initiatorEnabled = appConfiguration.Configuration.AppSettings.Settings["initiator_enabled"].Value;
            Log.Info("Initiator enabled=" + initiatorEnabled);
            if (initiatorEnabled.Equals("true"))
            {
                string initiatorConfigFile = appConfiguration.Configuration.AppSettings.Settings["initiator_settings"].Value;

                SessionSettings fixSettings = new SessionSettings(initiatorConfigFile);
                IFixDataDictionaries dataDictionaries = new FixDataDictionaries(fixSettings);

                initiator = BuildFixConnector(fixSettings, (fixapp, settings) => fixConnectorFactory.CreateInitiator(fixapp, settings));
            }

            acceptor?.Start();
            initiator?.Start();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Press X to quit");
            }
            while (Console.ReadKey().Key != ConsoleKey.X);

            acceptor?.Stop();
            initiator?.Stop();
        }

        private static IFixConnector BuildFixConnector(SessionSettings fixSettings,
                                                       Func<IApplication, SessionSettings, IFixConnector> builder)
        {
            string historizerOutputFileName = fixSettings.GetDefaultSettingValue<string>("MessageHistorizationFile");

            IFixMessageHistorizer messageHistorizer = new FixMessageFileHistorizer(historizerOutputFileName);
            IFixMessageHandler messageHandler = new FixMessageHandler();
            IApplication fixApp = new FixApplication(messageHandler, messageHistorizer);

            return builder(fixApp, fixSettings);
        }
    }
}
