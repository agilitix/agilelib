using System;

namespace AxConfiguration.ConfigFileProvider
{
    public class AppConfigFileProvider : ConfigFileProvider
    {
        private static readonly string[] DefaultAppFiles =
        {
            string.Format("app.{0}.config", Environment.UserName),
            string.Format("app.{0}.config", Environment.MachineName),
            "app.main.config"
        };

        public AppConfigFileProvider(string configFolder)
            : base(configFolder, DefaultAppFiles)
        {
        }
    }
}
