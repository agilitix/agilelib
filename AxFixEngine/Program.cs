using System;
using System.Collections.Generic;
using System.Reflection;
using AxCommandLine;
using AxCommandLine.Interfaces;
using AxConfiguration;
using AxConfiguration.Interfaces;
using AxUtils;
using log4net;
using Microsoft.Practices.Unity;

namespace AxFixEngine
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            const string configfile = @".\Configuration\fixengine.config";

            IAppConfiguration appConfiguration = new AppConfiguration();
            appConfiguration.Load(configfile);

            string log4netConfigFile;
            if (!appConfiguration.TryGetSetting("log4net", out log4netConfigFile))
            {
                Console.WriteLine("Cannot get key 'log4net' from config file=" + configfile);
                Console.ReadLine();
                return;
            }

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4netConfigFile));

            Log.Info("Starting FIX engine version=" + Assembly.GetEntryAssembly().GetName().Version);

            ICommandLineArguments commandLineArguments = new CommandLineArguments(args);
            Log.Info("Command line arguments: " + commandLineArguments);

            Log.Info("Loading unity container");
            IUnityContainer unity = new UnityContainer();
            unity.Load(appConfiguration);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
