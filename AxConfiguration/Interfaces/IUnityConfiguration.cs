﻿using Microsoft.Practices.Unity;

namespace AxConfiguration.Interfaces
{
    public interface IUnityConfiguration
    {
        IUnityContainer Container { get; }
        string ConfigurationFile { get; }

        void LoadFile(string configurationFile);
    }
}
