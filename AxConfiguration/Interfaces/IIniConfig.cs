using System.Collections.Generic;

namespace AxConfiguration.Interfaces
{
    public interface IIniSection
    {
        string Name { get; }
        IDictionary<string, string> Settings { get; }
    }

    public interface IIniConfig
    {
        string ConfigFile { get; }
        IList<IIniSection> Sections { get; }
    }
}
