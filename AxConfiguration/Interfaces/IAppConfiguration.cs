using System.Configuration;

namespace AxConfiguration.Interfaces
{
    public interface IAppConfiguration
    {
        Configuration Configuration { get; }

        T GetSetting<T>(string key);
        bool TryGetSetting<T>(string key, out T value);

        string ConfigurationFile { get; }
        void Load(string configurationFile);

        string[] DefaultConfigurationFiles { get; }
        void LoadDefaultConfigurationFile(string configurationFolder);
    }
}
