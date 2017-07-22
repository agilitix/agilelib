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
using AxFixEngine.Dialects;
using AxFixEngine.Extensions;
using AxFixEngine.Factories;
using AxFixEngine.Handlers;
using AxFixEngine.Interfaces;
using AxFixEngine.Utilities;
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

            IFixConnectorFactory connectorFactory = new FixConnectorFactory();

            IFixConnector acceptor = null;
            bool acceptorEnabled = appConfiguration.Configuration.GetSetting<bool>("acceptor_enabled");
            if (acceptorEnabled)
            {
                string configFile = appConfiguration.Configuration.GetSetting<string>("acceptor_settings");

                SessionSettings fixSettings = new SessionSettings(configFile);

                FixDialectsProvider.Initialize(new FixDialects(fixSettings));

                IFixMessageHandler messageHandler = unityConfiguration.Configuration.Resolve<IFixMessageHandler>();
                IApplication fixApp = new FixApplication(messageHandler);

                acceptor = connectorFactory.CreateAcceptor(fixApp, fixSettings);
            }

            IFixConnector initiator = null;
            bool initiatorEnabled = appConfiguration.Configuration.GetSetting<bool>("initiator_enabled");
            if (initiatorEnabled)
            {
                string configFile = appConfiguration.Configuration.GetSetting<string>("initiator_settings");

                SessionSettings fixSettings = new SessionSettings(configFile);

                FixDialectsProvider.Initialize(new FixDialects(fixSettings));

                IFixMessageHandler messageHandler = unityConfiguration.Configuration.Resolve<IFixMessageHandler>();
                IApplication fixApp = new FixApplication(messageHandler);

                initiator = connectorFactory.CreateInitiator(fixApp, fixSettings);
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
    }
}
