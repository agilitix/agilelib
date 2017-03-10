using System.Configuration;

namespace AxConfiguration.Interfaces
{
    public interface IAppConfiguration
    {
        Configuration Configuration { get; }

        string GetSetting(string key);
        bool TryGetSetting(string key, out string value);

        string ConfigurationFile { get; }
        void Load(string configurationFile);

        string[] DefaultConfigurationFiles { get; }
        void LoadDefaultConfigurationFile(string configurationFolder);
    }
}
