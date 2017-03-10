
using System.Collections.Generic;

namespace AxUtils.Interfaces
{
    public interface IIniFileReader
    {
        /// <summary>
        /// Get all the sections for given section name, a section is a dictionary of key/value pairs.
        /// </summary>
        IEnumerable<IDictionary<string, string>> GetSections(string sectionName);
    }
}
