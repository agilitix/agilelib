﻿using System.Configuration;

namespace AxConfiguration.Interfaces
{
    public interface IAppConfiguration
    {
        Configuration Configuration { get; }

        void LoadDefaultFile(string configurationFolder);
        void LoadFile(string configurationFile);
    }
}
