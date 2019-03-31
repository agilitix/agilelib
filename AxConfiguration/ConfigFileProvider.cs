using System;
using System.IO;
using System.Linq;
using System.Net;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class ConfigFileProvider : IConfigFileProvider
    {
        public string ConfigDirectory { get; }

        public ConfigFileProvider(string configDirectory)
        {
            if (!Directory.Exists(configDirectory))
            {
                throw new DirectoryNotFoundException($"Config directory '{configDirectory}' not found");
            }

            ConfigDirectory = configDirectory;
        }

        public string GetConfigFile(string baseName)
        {
            // .\Config\{baseName}.host.somehost.config
            // .\Config\{baseName}.user.awindowsacccount.config
            // .\Config\{baseName}.config
            string[] possibleConfigFiles =
            {
                Path.Combine(ConfigDirectory, $"{baseName}.host.{Dns.GetHostName().ToLower()}.config"),
                Path.Combine(ConfigDirectory, $"{baseName}.user.{Environment.UserName.ToLower()}.config"),
                Path.Combine(ConfigDirectory, $"{baseName}.config"),
            };

            return possibleConfigFiles.FirstOrDefault(File.Exists);
        }
    }
}
