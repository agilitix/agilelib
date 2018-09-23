using System.Collections.Generic;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class IniSection : IIniSection
    {
        public string Name { get; }
        public IDictionary<string, string> Settings { get; }

        public IniSection(string name)
        {
            Name = name;
            Settings = new Dictionary<string, string>();
        }
    }

    public class IniConfiguration : IIniConfiguration
    {
        private readonly IList<IIniSection> _sections = new List<IIniSection>();

        public IEnumerable<IIniSection> Configuration => _sections;
        public string ConfigurationFile { get; private set; }

        public IniConfiguration()
        {
        }

        public IniConfiguration(string iniFileName)
        {
            LoadConfiguration(iniFileName);
        }

        public void LoadConfiguration(string iniFileName)
        {
            if (!File.Exists(iniFileName))
            {
                throw new FileNotFoundException(nameof(iniFileName), iniFileName);
            }

            ConfigurationFile = iniFileName;

            const string commentsMarker = ";#";
            IIniSection iniSection = null;

            string[] lines = File.ReadAllLines(iniFileName);
            foreach (string line in lines)
            {
                string trimLine = line.Trim();
                if (trimLine.Length > 0 && !commentsMarker.Contains(trimLine[0]))
                {
                    if (trimLine.StartsWith("[") && trimLine.EndsWith("]"))
                    {
                        string sectionName = trimLine.Trim('[', ']').Trim();
                        iniSection = new IniSection(sectionName);
                        _sections.Add(iniSection);
                    }
                    else if (trimLine.IndexOf('=') != -1 && iniSection != null)
                    {
                        string[] keyValue = trimLine.Split(new[] {'='}, 2);
                        iniSection.Settings.Add(keyValue[0].Trim(), keyValue[1].Trim());
                    }
                }
            }
        }
    }
}
