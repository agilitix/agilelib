﻿using System;
using System.Configuration;
using System.IO;
using System.Linq;
using AxConfiguration.Interfaces;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace AxConfiguration
{
    public class UnityConfiguration : IUnityConfiguration
    {
        protected AliasElementCollection _baseAliases;
        protected readonly string _containerName;

        public IUnityContainer Configuration { get; private set; }
        public string ConfigurationFile { get; private set; }

        public UnityConfiguration()
        {
            _containerName = "";
        }

        public UnityConfiguration(string unityFileName)
            : this(unityFileName, "")
        {
        }

        public UnityConfiguration(string unityFileName, string containerName)
        {
            _containerName = string.IsNullOrWhiteSpace(containerName) ? "" : containerName;
            LoadConfiguration(unityFileName);
        }

        public void LoadConfiguration(string configurationFile)
        {
            if (!File.Exists(configurationFile))
            {
                throw new FileNotFoundException();
            }

            ConfigurationFile = configurationFile;
            Configuration = new UnityContainer();

            LoadUnityContainer(Configuration, configurationFile, _containerName);

            _baseAliases = null;
        }

        protected void LoadUnityContainer(IUnityContainer unityContainer, string configurationFileName, string containerName)
        {
            // Open the configurationFileName file.
            var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = configurationFileName};
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            // Walk to the most top base file and start loading unity from there.
            KeyValueConfigurationElement baseFiles = configuration.AppSettings.Settings["base"];
            if (baseFiles != null)
            {
                string[] files = baseFiles.Value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string file in files)
                {
                    string baseFile = Path.Combine(Path.GetDirectoryName(configurationFileName), file.Trim());
                    if (!File.Exists(baseFile))
                    {
                        throw new FileNotFoundException(string.Format("Configuration file '{0}' not found", baseFile));
                    }

                    // Go to base file.
                    LoadUnityContainer(unityContainer, baseFile, containerName);
                }
            }

            // We are at the top of the config files hierarchy, start reading the files from there to the bottom hierarchy.
            UnityConfigurationSection unitySection = (UnityConfigurationSection) configuration.GetSection("unity");

            // Propagate base aliases to children. Other declarations than aliases are not inherited.
            if (_baseAliases != null)
            {
                foreach (AliasElement baseAlias in _baseAliases)
                {
                    if (unitySection.TypeAliases.Any(x => x.Alias == baseAlias.Alias))
                    {
                        continue;
                    }

                    unitySection.TypeAliases[baseAlias.Alias] = baseAlias.TypeName;
                }
            }

            _baseAliases = unitySection.TypeAliases;

            unityContainer.LoadConfiguration(unitySection, containerName);
        }
    }
}
