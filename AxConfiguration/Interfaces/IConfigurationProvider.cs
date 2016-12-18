using System.Configuration;

namespace AxConfiguration.Interfaces
{
    public interface IConfigurationProvider
    {
        string ConfigurationFile { get; }
        Configuration Configuration { get; }
    }
}
