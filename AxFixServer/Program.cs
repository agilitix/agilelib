﻿using System;
using System.Reflection;
using AxCommandLine;
using AxCommandLine.Interfaces;
using AxConfiguration;
using AxConfiguration.Interfaces;
using AxFixEngine;
using AxFixEngine.Extensions;
using AxFixEngine.Interfaces;
using log4net;
using Microsoft.Practices.Unity;
using QuickFix;
using ILog = log4net.ILog;

namespace AxFixServer
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            const string configfile = @".\Configuration\fixengine.config";

            IAppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Load(configfile);

            string log4NetConfigFile;
            if (!appConfiguration.TryGetSetting("log4net", out log4NetConfigFile))
            {
                Console.WriteLine("Cannot get key 'log4net' from config file=" + configfile);
                Console.ReadLine();
                return;
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4NetConfigFile));

            Log.Info("Starting FIX engine version=" + Assembly.GetEntryAssembly().GetName().Version);

            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);
            Log.Info("Command line arguments: " + commandLineArguments);

            Log.Info("Loading unity container");
            IUnityContainer unity = new UnityContainer();
            unity.Load(appConfiguration);

            IFixConnectorFactory fixConnectorFactory = new FixConnectorFactory();
            IFixConnector acceptor = null;
            IFixConnector initiator = null;

            bool acceptorEnabled = appConfiguration.GetSetting<bool>("acceptor_enabled");
            Log.Info("Acceptor enabled=" + acceptorEnabled);
            if (acceptorEnabled)
            {
                string acceptorConfigFile = appConfiguration.GetSetting<string>("acceptor_settings");

                SessionSettings fixSettings = new SessionSettings(acceptorConfigFile);
                IFixDataDictionaries dataDictionaries = new FixDataDictionaries(fixSettings);

                acceptor = BuildFixConnector(fixSettings, (fixapp, settings) => fixConnectorFactory.CreateAcceptor(fixapp, settings));
            }

            bool initiatorEnabled = appConfiguration.GetSetting<bool>("initiator_enabled");
            Log.Info("Initiator enabled=" + initiatorEnabled);
            if (initiatorEnabled)
            {
                string initiatorConfigFile = appConfiguration.GetSetting<string>("initiator_settings");

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
