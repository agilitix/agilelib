using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using AxCommandLine;
using AxCommandLine.Interfaces;
using AxCommonLogger;
using AxCommonLogger.Factories;
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
        protected static ILoggerFacade Logger;

        static Program()
        {
            Console.TreatControlCAsInput = false;
            Console.CancelKeyPress += (snd, evt) =>
                                      {
                                          Console.WriteLine("Ctrl+C pressed");
                                          evt.Cancel = true;
                                      };
        }

        static void Main(string[] args)
        {
            // Lookup configuration files in config folder.
            IConfigurationFileProvider configurationFileProvider = new ConfigurationFileProvider(@".\Configuration");

            // Read app configuration.
            IAppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.LoadConfiguration(configurationFileProvider.AppConfigFile);

            string log4NetConfigFile = appConfiguration.Configuration.GetSetting<string>("log4net");
            if (string.IsNullOrWhiteSpace(log4NetConfigFile))
            {
                Console.WriteLine("Cannot get key 'log4net' from config file=" + appConfiguration.ConfigurationFile);
                Console.ReadLine();
                return;
            }

            // Init logger.
            ILoggerFacadeFactory loggerFacadeFactory = new Log4netLoggerFacadeFactory();
            loggerFacadeFactory.Configure(log4NetConfigFile);
            LoggerFacadeProvider.Initialize(loggerFacadeFactory);
            Logger = LoggerFacadeProvider.GetDeclaringTypeLogger();

            // Log some useful infos.
            Logger.Info("Starting FIX engine version=" + Assembly.GetEntryAssembly().GetName().Version);
            Logger.Info("Main => PID=" + Process.GetCurrentProcess().Id + " / ThreadID=" + Thread.CurrentThread.ManagedThreadId);

            // Read Unity configuration.
            Logger.Info("Reading Unity container config");
            IUnityConfiguration unityConfiguration = new UnityConfiguration();
            unityConfiguration.LoadConfiguration(configurationFileProvider.IocConfigFile);

            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);
            Logger.Info("Command line arguments: " + commandLineArguments);

            IFixConnectorFactory connectorFactory = unityConfiguration.Configuration.Resolve<IFixConnectorFactory>();
            Logger.Info("Resolved FIX connection factory type=" + connectorFactory.GetType());

            IFixConnector acceptor = CreateConnector("acceptor", appConfiguration, unityConfiguration, connectorFactory);
            IFixConnector initiator = CreateConnector("initiator", appConfiguration, unityConfiguration, connectorFactory);

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

        private static IFixConnector CreateConnector(string connectorType,
                                                     IAppConfiguration appConfiguration,
                                                     IUnityConfiguration unity,
                                                     IFixConnectorFactory fixConnectorFactory)
        {
            bool connectorEnabled = appConfiguration.Configuration.GetSetting<bool>(connectorType + "_enabled");
            Logger.Info(connectorType + " enabled=" + connectorEnabled);
            if (!connectorEnabled)
            {
                return null;
            }

            string initiatorConfigFile = appConfiguration.Configuration.GetSetting<string>(connectorType + "_settings");

            SessionSettings fixSettings = new SessionSettings(initiatorConfigFile);
            IFixDataDictionaries dataDictionaries = new FixDataDictionaries(fixSettings);

            string historizerOutputFileName = fixSettings.GetDefaultSettingValue<string>("MessageHistorizationFile");

            IFixMessageHistorizer messageHistorizer = new FixMessageFileHistorizer(historizerOutputFileName);
            IFixMessageHandler messageHandler = unity.Configuration.Resolve<IFixMessageHandler>();
            IApplication fixApp = new FixApplication(messageHandler, messageHistorizer);

            if (connectorType.Equals("initiator"))
            {
                return fixConnectorFactory.CreateInitiator(fixApp, fixSettings);
            }
            if (connectorType.Equals("acceptor"))
            {
                return fixConnectorFactory.CreateAcceptor(fixApp, fixSettings);
            }

            return null;
        }
    }
}
