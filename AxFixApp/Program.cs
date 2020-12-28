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
using AxFixEngine.Engine;
using AxUtils;

namespace AxFixApp
{
    class Program
    {
        protected static ILoggerFacade Logger;

        static void Main(string[] args)
        {
            // Set the default culture everywhere.
            CultureInfoUtils.SetDefaultCultureInfo_en_US();

            // Read the app configuration.
            IAppConfig appConfig = new AppConfig(@".\Config\app.main.config");

            // Get the log4net config name.
            string log4NetConfigFile = appConfig.GetKey<string>("log4net");
            if (string.IsNullOrWhiteSpace(log4NetConfigFile))
            {
                Console.WriteLine("Cannot get key 'log4net' from config file=" + appConfig.ConfigFile);
                Console.ReadLine();
                return;
            }

            // Init the internal logger based on log4net.
            ILoggerFacadeFactory loggerFacadeFactory = new Log4netLoggerFacadeFactory();
            loggerFacadeFactory.Configure(log4NetConfigFile);
            LoggerFacadeProvider.Initialize(loggerFacadeFactory);
            Logger = LoggerFacadeProvider.GetDeclaringTypeLogger();

            // Log some useful infos.
            Logger.Info("Starting FIX engine version=" + Assembly.GetEntryAssembly()?.GetName().Version);
            Logger.Info("Main => PID=" + Process.GetCurrentProcess().Id + " / ThreadID=" + Thread.CurrentThread.ManagedThreadId);

            // Command line parser.
            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);
            Logger.Info("Command line arguments: " + commandLineArguments);


            // Create the fix engine manager and build the acceptor/initiator engines.
            IFixEngineManager fixEngineManager = new FixEngineManager();

            if (appConfig.GetKey<bool>("acceptor_enabled"))
            {
                var acceptorConfig = appConfig.GetKey<string>("acceptor_settings");
                fixEngineManager.CreateFixEngine(acceptorConfig);
            }

            if (appConfig.GetKey<bool>("initiator_enabled"))
            {
                var initiatorConfig = appConfig.GetKey<string>("initiator_settings");
                fixEngineManager.CreateFixEngine(initiatorConfig);
            }

            // Start the acceptor/initiator engines.
            fixEngineManager.Start();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Press X to quit");
            }
            while (Console.ReadKey().Key != ConsoleKey.X);

            // Stop the acceptor/initiator engines.
            fixEngineManager.Stop();
        }
    }
}
