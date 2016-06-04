﻿using System.IO;
using AxConfiguration.Interfaces;

namespace AxConfiguration.ConfigFileProvider
{
    public class ConfigFileProvider : IConfigFileProvider
    {
        private readonly string _configFolder;
        private readonly string[] _configFileNamesToTry;
        private readonly string _defaultConfigFile = "app.config";

        public ConfigFileProvider(string configFolder, string[] configFileNamesToTry)
        {
            _configFolder = configFolder;
            _configFileNamesToTry = configFileNamesToTry;
        }

        public string GetMainConfigFile()
        {
            foreach (string fileName in _configFileNamesToTry)
            {
                string filePath = Path.Combine(_configFolder, fileName);
                if (File.Exists(filePath))
                {
                    return filePath;
                }
            }

            if (File.Exists(_defaultConfigFile))
            {
                return _defaultConfigFile;
            }

            throw new FileNotFoundException("Main configuration file not found");
        }
    }
}
