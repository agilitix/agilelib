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

            // Create the fix engine manager and build the internal fix engines,
            // one for the acceptor then one for the initiator.
            // Nothing happens if the corresponding config file does not exits.
            IFixEngineManager fixEngineManager = new FixEngineManager();
            fixEngineManager.CreateFixEngine(acceptorConfig);
            fixEngineManager.CreateFixEngine(initiatorConfig);
            fixEngineManager.Start();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Press X to quit");
            }
            while (Console.ReadKey().Key != ConsoleKey.X);

            // Stop the internal fix engines.
            fixEngineManager.Stop();
        }
    }
}
