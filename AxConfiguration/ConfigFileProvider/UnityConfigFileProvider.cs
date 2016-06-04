using System;

namespace AxConfiguration.ConfigFileProvider
{
    public class UnityConfigFileProvider : ConfigFileProvider
    {
        private static readonly string[] DefaultUnityFiles =
        {
            string.Format("unity.{0}.config", Environment.UserName),
            string.Format("unity.{0}.config", Environment.MachineName),
            "unity.main.config"
        };

        public UnityConfigFileProvider(string configFolder)
            : base(configFolder, DefaultUnityFiles)
        {
        }
    }
}
