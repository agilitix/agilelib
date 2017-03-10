using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class AppConfiguration : IAppConfiguration
    {
        /// <summary>
        /// The first file found in the config folder will be used as default config file.
        /// </summary>
        protected static string[] _defaultConfigurationFiles =
        {
            string.Format("unity.{0}.config", Environment.UserName),
            string.Format("unity.{0}.config", Environment.MachineName),
            "unity.config",
            string.Format("main.{0}.config", Environment.UserName),
            string.Format("main.{0}.config", Environment.MachineName),
            "main.config",
            Path.GetFileName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile) // application.exe.config
        };

        public string[] DefaultConfigurationFiles => _defaultConfigurationFiles;

        public string ConfigurationFile { get; private set; }
        public Configuration Configuration { get; private set; }

        public string GetSetting(string key)
        {
            string value;
            TryGetSetting(key, out value);
            return value;
        }

        public bool TryGetSetting(string key, out string value)
        {
            IEnumerator enumerator = Configuration.AppSettings.Settings.GetEnumerator();
            while(enumerator.MoveNext())
            {
                KeyValueConfigurationElement elt = enumerator.Current as KeyValueConfigurationElement;
                if (elt != null && elt.Key == key)
                {
                    value = elt.Value;
                    return true;
                }
            }

            value = string.Empty;
            return false;
        }

        public void Load(string configurationFile)
        {
            if (string.IsNullOrWhiteSpace(configurationFile))
            {
                throw new ArgumentException();
            }
            if (!File.Exists(configurationFile))
            {
                throw new FileNotFoundException();
            }

            ConfigurationFile = configurationFile;
            ExeConfigurationFileMap exeConfigurationFileMap = new ExeConfigurationFileMap {ExeConfigFilename = ConfigurationFile};
            Configuration = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
        }

        public void LoadDefaultConfigurationFile(string configurationFolder)
        {
            if (!Directory.Exists(configurationFolder))
            {
                throw new ArgumentException();
            }

            string defaultConfigurationFile = GetDefaultConfigurationFile(configurationFolder);
            Load(defaultConfigurationFile);
        }

        protected string GetDefaultConfigurationFile(string configurationFolder)
        {
            return _defaultConfigurationFiles.Select(fileName => Path.Combine(configurationFolder, fileName))
                                             .FirstOrDefault(File.Exists);
        }
    }
}
