using System;
using System.Collections.Generic;
using System.IO;
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

        public void LoadFile(string iniFileName)
        {
            if (!File.Exists(iniFileName))
            {
                throw new FileNotFoundException(nameof(iniFileName), iniFileName);
            }

            const string commentsMarker = ";#";
            IIniFileSection iniFileSection = null;

            string[] lines = System.IO.File.ReadAllLines(iniFileName);
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

        public IEnumerable<IIniFileSection> GetSections()
        {
            return _sections;
        }
    }
}
