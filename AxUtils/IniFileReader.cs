
using System.Collections.Generic;
using System.Linq;
using AxUtils.Interfaces;

namespace AxUtils
{
    public class IniFileReader : IIniFileReader
    {
        private readonly IList<IniSection> _sections = new List<IniSection>();

        private class IniSection
        {
            public string Name;
            public IDictionary<string, string> Entries;
        }

        public IniFileReader(string inifile)
        {
            const string commentMarkers = ";#'";
            IniSection iniSection = null;

            string[] lines = System.IO.File.ReadAllLines(inifile);
            foreach (string line in lines)
            {
                string trimLine = line.Trim();
                if (trimLine.Length > 0 && !commentMarkers.Contains(trimLine[0]))
                {
                    if (trimLine.StartsWith("[") && trimLine.EndsWith("]"))
                    {
                        iniSection = new IniSection
                                     {
                                         Name = trimLine.Trim('[', ']').Trim(),
                                         Entries = new Dictionary<string, string>()
                                     };
                        _sections.Add(iniSection);
                    }
                    else if (trimLine.IndexOf('=') != -1 && iniSection?.Entries != null)
                    {
                        string[] keyValue = trimLine.Split(new[] {'='}, 2);
                        iniSection.Entries.Add(keyValue[0].Trim(), keyValue[1].Trim());
                    }
                }
            }
        }

        public IEnumerable<IDictionary<string, string>> GetSections(string sectionName)
        {
            return _sections.Where(x => x.Name == sectionName).Select(x => x.Entries);
        }
    }
}
