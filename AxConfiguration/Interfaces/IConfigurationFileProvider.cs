namespace AxConfiguration.Interfaces
{
    public interface IConfigurationFileProvider
    {
        string ConfigFolder { get; }

        string AppConfigFile { get; }
        string IocConfigFile { get; }
        string IniConfigFile { get; }
    }
}
