using System.Configuration;

namespace AxConfiguration.Interfaces
{
    public interface IAppConfiguration
    {
        Configuration Configuration { get; }
        string ConfigurationFile { get; }

        void LoadConfiguration(string configurationFile);
    }
}
