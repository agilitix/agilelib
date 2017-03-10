
using System.Collections.Generic;

namespace AxUtils.Interfaces
{
    public interface IIniFileReader
    {
        /// <summary>
        /// Get all the sections for given section name, a section is a dictionary of key/value pairs.
        /// </summary>
        IEnumerable<IDictionary<string, string>> GetAllSections(string sectionName);

        /// <summary>
        /// Get first section with given name.
        /// </summary>
        IDictionary<string, string> GetSection(string sectionName);

        /// <summary>
        /// Get first section param with given name.
        /// </summary>
        T GetSetting<T>(string sectionName, string keyName);
    }
}
