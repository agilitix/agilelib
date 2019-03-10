namespace AxConfiguration.Interfaces
{
    public interface IConfigFileProvider
    {
        string ConfigDirectory { get; }

        string GetConfigFile(string baseName);
    }
}