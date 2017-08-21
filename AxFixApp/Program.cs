using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using AxCommandLine;
using AxCommandLine.Interfaces;
using AxCommonLogger;
using AxCommonLogger.Factories;
using AxCommonLogger.Interfaces;
using AxConfiguration;
using AxConfiguration.Interfaces;
using AxFixEngine.Dialects;
using AxFixEngine.Engine;
using AxFixEngine.Extensions;
using AxFixEngine.Factories;
using AxFixEngine.Handlers;
using AxFixEngine.Interfaces;
using QuickFix;
using QuickFix.FixValues;

namespace AxFixApp
{
    class Program
    {
        protected static ILoggerFacade Logger;

        static Program()
        {
#if DEBUG == false
            Console.TreatControlCAsInput = false;
            Console.CancelKeyPress += (snd, evt) =>
                                      {
                                          Console.WriteLine("Ctrl+C pressed");
                                          evt.Cancel = true;
                                      };
#endif
        }

        static void Main(string[] args)
        {
            // Lookup configuration files in config folder.
            IConfigurationFileProvider configurationFileProvider = new ConfigurationFileProvider(@".\Config");

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

            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);
            Logger.Info("Command line arguments: " + commandLineArguments);

            string acceptorConfig = null, initiatorConfig = null;
            if (appConfiguration.Configuration.GetSetting<bool>("acceptor_enabled"))
            {
                acceptorConfig = appConfiguration.Configuration.GetSetting<string>("acceptor_settings");
            }
            if (appConfiguration.Configuration.GetSetting<bool>("initiator_enabled"))
            {
                initiatorConfig = appConfiguration.Configuration.GetSetting<string>("initiator_settings");
            }

            IFixEngine fixEngine = new FixEngine(acceptorConfig, initiatorConfig);

            IFixMessageHandlerProvider handlerProvider = new FixMessageHandlerProvider();
            IFixMessageHandler fix44InboundMessageCracker = new Fix44MessageCracker();
            IFixMessageHandler fix44OutboundMessageCracker = new Fix44OutboundMessageCracker();

            foreach (SessionID sessionId in fixEngine.Sessions.Where(x => x.BeginString == BeginString.FIX44))
            {
                handlerProvider.AddMessageHandler(sessionId, fix44OutboundMessageCracker);
                handlerProvider.AddMessageHandler(sessionId.GetReverseSessionID(), fix44InboundMessageCracker);
            }

            fixEngine.CreateApplication(handlerProvider);

            fixEngine.Start();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Press X to quit");
            }
            while (Console.ReadKey().Key != ConsoleKey.X);

            fixEngine.Stop();
        }
    }
}
