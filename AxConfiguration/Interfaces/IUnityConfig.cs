using Unity;

namespace AxConfiguration.Interfaces
{
    public interface IUnityConfig
    {
        string ConfigFile { get; }
        string ContainerName { get; }

        bool IsRegistered<T>(string name = "");
        T Resolve<T>(string name = "");
    }
}
