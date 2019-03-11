using System.Collections.Generic;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;

namespace AxConfiguration
{
    public class IniSection : IIniSection
    {
        public string Name { get; }
        public IDictionary<string, string> Settings { get; } = new Dictionary<string, string>();

        public IniSection(string name)
        {
            Name = name;
        }
    }

    public class IniConfig : IIniConfig
    {
        public string ConfigFile { get; }
        public IList<IIniSection> Sections { get; } = new List<IIniSection>();

        public IniConfig(string configFile)
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException("Ini config file not found", configFile);
            }

            ConfigFile = configFile;

            using (StreamReader sr = File.OpenText(ConfigFile))
            {
                const string commentsMarker = ";#";
                IIniSection iniSection = null;

                string trimLine;
                while ((trimLine = sr.ReadLine()?.Trim()) != null)
                {
                    if (string.IsNullOrWhiteSpace(trimLine) || commentsMarker.Contains(trimLine[0]))
                    {
                        continue;
                    }

                    int index;
                    if (trimLine.StartsWith("[") && trimLine.EndsWith("]"))
                    {
                        string sectionName = trimLine.Trim('[', ']').Trim();
                        iniSection = new IniSection(sectionName);
                        Sections.Add(iniSection);
                    }
                    else if ((index = trimLine.IndexOf('=')) != -1 && iniSection != null)
                    {
                        string key = trimLine.Substring(0, index++);
                        string value = index < trimLine.Length
                                           ? trimLine.Substring(index)
                                           : string.Empty;
                        iniSection.Settings.Add(key.Trim(), value.Trim());
                    }
                }
            }
        }
    }
}
