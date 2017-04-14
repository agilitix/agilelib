using System.Collections.Generic;

namespace AxConfiguration.Interfaces
{
    public interface IIniSection
    {
        string Name { get; }
        IDictionary<string, string> Settings { get; }
    }

    public interface IIniConfiguration
    {
        string ConfigurationFile { get; }
        IEnumerable<IIniSection> Configuration { get; }

        void LoadConfiguration(string iniFileName);
    }
}
