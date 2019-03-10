using System.Configuration;

namespace AxConfiguration.Interfaces
{
    public interface IAppConfig
    {
        string ConfigFile { get; }

        bool ContainsKey(string key);
        T GetKey<T>(string key, T defaultValue = default(T));
        bool TryGetKey<T>(string key, out T value, T defaultValue = default(T));
    }
}
