using Microsoft.Practices.Unity;

namespace AxConfiguration.Interfaces
{
    public interface IUnityConfiguration
    {
        IUnityContainer Container { get; }
        string ConfigurationFile { get; }

        void LoadDefaultFile(string configurationFolder);
        void LoadFile(string configurationFile);
    }
}
