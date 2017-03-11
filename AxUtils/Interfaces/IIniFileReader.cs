using System.Collections.Generic;

namespace AxUtils.Interfaces
{
    public interface IIniFileSection
    {
        string Name { get; }
        IDictionary<string, string> Settings { get; }
    }

    public interface IIniFileReader
    {
        /// <summary>
        /// Get all the sections.
        /// </summary>
        IEnumerable<IIniFileSection> GetAllSections();

        /// <summary>
        /// Get all sections having given section name.
        /// </summary>
        IEnumerable<IIniFileSection> GetAllSections(string sectionName);

        /// <summary>
        /// Get first section with given name.
        /// </summary>
        IIniFileSection GetSection(string sectionName);

        /// <summary>
        /// Get first section param with given name.
        /// </summary>
        T GetSetting<T>(string sectionName, string keyName);
    }
}