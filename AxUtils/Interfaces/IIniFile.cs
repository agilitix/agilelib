using System.Collections.Generic;

namespace AxUtils.Interfaces
{
    public interface IIniFileSection
    {
        string Name { get; }
        IDictionary<string, string> Settings { get; }
    }

    public interface IIniFile
    {
        /// <summary>
        /// Load ini file.
        /// </summary>
        void LoadFile(string iniFileName);

        /// <summary>
        /// Get all sections.
        /// </summary>
        IEnumerable<IIniFileSection> GetSections();
    }
}