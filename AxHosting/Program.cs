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

            IConfigurationProvider configurationProvider = new ConfigurationProvider();
            string fileName = configurationProvider.Configuration.AppSettings.Settings["app.log4net.config"].Value;
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(fileName));

            Log.Info("test2");

            // TODO

            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }
    }
}
