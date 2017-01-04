using System.Configuration;

namespace AxConfiguration.Interfaces
{
    public interface IConfigurationProvider
    {
        Configuration Configuration { get; }

        string ConfigurationFile { get; }
        void LoadConfigurationFile(string configurationFile);

        string[] DefaultConfigurationFiles { get; }
        void LoadDefaultConfigurationFile(string configurationFolder);
    }
}
