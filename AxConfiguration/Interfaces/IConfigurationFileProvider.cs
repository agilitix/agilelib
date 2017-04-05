namespace AxConfiguration.Interfaces
{
    public interface IConfigurationFileProvider
    {
        string ConfigFolder { get; }

        string AppConfigFile { get; }
        string UnityConfigFile { get; }
    }
}
