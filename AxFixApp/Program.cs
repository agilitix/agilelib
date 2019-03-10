using System;
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
using AxFixEngine.Engine;
using AxFixEngine.Handlers;
using AxUtils;
using QuickFix;

namespace AxFixApp
{
    class Program
    {
        protected static ILoggerFacade Logger;

        static void Main(string[] args)
        {
            // Set culture overall app and threads.
            CultureInfoUtils.SetDefaultCultureInfo_en_US();

            // Read app configuration.
            IAppConfig appConfig = new AppConfig(@".\Config\app.main.config");

            string log4NetConfigFile = appConfig.GetKey<string>("log4net");
            if (string.IsNullOrWhiteSpace(log4NetConfigFile))
            {
                Console.WriteLine("Cannot get key 'log4net' from config file=" + appConfig.ConfigFile);
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

            string initiatorConfig = null;
            if (appConfig.GetKey<bool>("initiator_enabled"))
            {
                initiatorConfig = appConfig.GetKey<string>("initiator_settings");
            }

            string acceptorConfig = null;
            if (appConfig.GetKey<bool>("acceptor_enabled"))
            {
                acceptorConfig = appConfig.GetKey<string>("acceptor_settings");
            }

            // Create initiator fix engines.
            IFixEngine initiator = new FixEngine(initiatorConfig);
            initiator.CreateApplication();
            initiator.Start();

            // Create acceptor fix engines.
            IFixEngine acceptor = new FixEngine(acceptorConfig);
            acceptor.CreateApplication();
            acceptor.Start();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Press X to quit");
            }
            while (Console.ReadKey().Key != ConsoleKey.X);

            acceptor.Stop();
            initiator.Stop();
        }
    }
}
