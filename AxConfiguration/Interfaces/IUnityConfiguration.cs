using Microsoft.Practices.Unity;

namespace AxConfiguration.Interfaces
{
    public interface IUnityConfiguration
    {
        IUnityContainer Configuration { get; }
        string ConfigurationFile { get; }

        void LoadConfiguration(string configurationFile);
    }
}
