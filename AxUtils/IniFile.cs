using System;
using System.Collections.Generic;
using System.Linq;
using AxUtils.Interfaces;

namespace AxUtils
{
    public class IniFileSection : IIniFileSection
    {
        public string Name { get; }
        public IDictionary<string, string> Settings { get; }

        public IniFileSection(string name)
        {
            Name = name;
            Settings = new Dictionary<string, string>();
        }
    }

    public class IniFile : IIniFile
    {
        private readonly IList<IIniFileSection> _sections = new List<IIniFileSection>();

        public IniFile(string inifile)
        {
            const string commentsMarker = ";#'";
            IIniFileSection iniFileSection = null;

            string[] lines = System.IO.File.ReadAllLines(inifile);
            foreach (string line in lines)
            {
                string trimLine = line.Trim();
                if (trimLine.Length > 0 && !commentsMarker.Contains(trimLine[0]))
                {
                    if (trimLine.StartsWith("[") && trimLine.EndsWith("]"))
                    {
                        string sectionName = trimLine.Trim('[', ']').Trim();
                        iniFileSection = new IniFileSection(sectionName);
                        _sections.Add(iniFileSection);
                    }
                    else if (trimLine.IndexOf('=') != -1 && iniFileSection != null)
                    {
                        string[] keyValue = trimLine.Split(new[] {'='}, 2);
                        iniFileSection.Settings.Add(keyValue[0].Trim(), keyValue[1].Trim());
                    }
                }
            }
        }

        public T GetSetting<T>(string sectionName, string keyName)
        {
            string keyValue;
            IIniFileSection section = GetSection(sectionName);
            if (section != null && section.Settings.TryGetValue(keyName, out keyValue))
            {
                return (T) Convert.ChangeType(keyValue, typeof(T));
            }
            throw new ArgumentException();
        }

        public IEnumerable<IIniFileSection> GetAllSections()
        {
            return _sections;
        }

        public IEnumerable<IIniFileSection> GetAllSections(string sectionName)
        {
            return _sections.Where(s => s.Name == sectionName);
        }

        public IIniFileSection GetSection(string sectionName)
        {
            return _sections.FirstOrDefault(s => s.Name == sectionName);
        }
    }
}
