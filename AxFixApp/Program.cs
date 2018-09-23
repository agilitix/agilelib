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
            IAppConfiguration appConfiguration = new AppConfiguration(@".\Config\app.main.config");

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

            string initiatorConfig = null;
            if (appConfiguration.Configuration.GetSetting<bool>("initiator_enabled"))
            {
                initiatorConfig = appConfiguration.Configuration.GetSetting<string>("initiator_settings");
            }

            // Create the fix engine.
            IFixEngine fixEngine = new FixEngine(initiatorConfig);
            fixEngine.CreateApplication();
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
