using System;
using AxCommandLine;
using AxCommandLine.Interfaces;
using AxConfiguration;
using AxConfiguration.Interfaces;
using log4net;

namespace AxHosting
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);

            ICommandLineValidator commandLineValidator = new CommandLineValidator(commandLineArguments);
            if (!commandLineValidator.Validate())
            {
                Console.WriteLine(commandLineValidator.Usage);
                return;
            }

            IAppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.LoadDefaultConfigurationFile(".");

            string log4netConfigFile = appConfiguration.Configuration.AppSettings.Settings["log4net.config"].Value;
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4netConfigFile));

            Log.Info("test2");

            // TODO

            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }
    }
}
