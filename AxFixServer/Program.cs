using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
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
using Microsoft.Practices.Unity;
using QuickFix;

namespace AxFixServer
{
    class Program
    {
        protected static ILoggerFacade Log = new Log4netFacade<Program>();

        static Program()
        {
            ConsoleExitHandler.Setup();
        }

        static void Main(string[] args)
        {
            IConfigurationFileProvider configurationFileProvider = new ConfigurationFileProvider(@".\Configuration");

            IAppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.LoadFile(configurationFileProvider.AppConfigFile);

            string log4NetConfigFile = appConfiguration.Configuration.GetSetting<string>("log4net");
            if (string.IsNullOrWhiteSpace(log4NetConfigFile))
            {
                Console.WriteLine("Cannot get key 'log4net' from config file=" + appConfiguration.ConfigurationFile);
                Console.ReadLine();
                return;
            }

            Log.Configure(log4NetConfigFile);

            Log.Info("Starting FIX engine version=" + Assembly.GetEntryAssembly().GetName().Version);
            Log.Info("Main => PID=" + Process.GetCurrentProcess().Id + " / ThreadID=" + Thread.CurrentThread.ManagedThreadId);

            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);
            Log.Info("Command line arguments: " + commandLineArguments);

            IUnityConfiguration unity = new UnityConfiguration();
            unity.LoadFile(configurationFileProvider.UnityConfigFile);
            Log.Info("Loaded unity configuration from file=" + unity.ConfigurationFile);

            IFixConnectorFactory fixConnectorFactory = unity.Container.Resolve<IFixConnectorFactory>();
            Log.Info("Resolved FIX connection factory type=" + fixConnectorFactory.GetType());

            IFixConnector acceptor = null;
            IFixConnector initiator = null;

            bool acceptorEnabled = appConfiguration.Configuration.GetSetting<bool>("acceptor_enabled");
            Log.Info("Acceptor enabled=" + acceptorEnabled);
            if (acceptorEnabled)
            {
                string acceptorConfigFile = appConfiguration.Configuration.AppSettings.Settings["acceptor_settings"].Value;

                SessionSettings fixSettings = new SessionSettings(acceptorConfigFile);
                IFixDataDictionaries dataDictionaries = new FixDataDictionaries(fixSettings);

                acceptor = BuildFixConnector(unity, fixSettings, (fixapp, settings) => fixConnectorFactory.CreateAcceptor(fixapp, settings));
            }

            bool initiatorEnabled = appConfiguration.Configuration.GetSetting<bool>("initiator_enabled");
            Log.Info("Initiator enabled=" + initiatorEnabled);
            if (initiatorEnabled)
            {
                string initiatorConfigFile = appConfiguration.Configuration.AppSettings.Settings["initiator_settings"].Value;

                SessionSettings fixSettings = new SessionSettings(initiatorConfigFile);
                IFixDataDictionaries dataDictionaries = new FixDataDictionaries(fixSettings);

                initiator = BuildFixConnector(unity, fixSettings, (fixapp, settings) => fixConnectorFactory.CreateInitiator(fixapp, settings));
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

        private static IFixConnector BuildFixConnector(IUnityConfiguration unityConfiguration,
                                                       SessionSettings fixSettings,
                                                       Func<IApplication, SessionSettings, IFixConnector> builder)
        {
            string historizerOutputFileName = fixSettings.GetDefaultSettingValue<string>("MessageHistorizationFile");

            IFixMessageHistorizer messageHistorizer = new FixMessageFileHistorizer(historizerOutputFileName);
            IFixMessageHandler messageHandler = unityConfiguration.Container.Resolve<IFixMessageHandler>();
            IApplication fixApp = new FixApplication(messageHandler, messageHistorizer);

            return builder(fixApp, fixSettings);
        }
    }
}
