using System;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;

namespace AxConfiguration.UnitTests.Test.Logger.Implementations
{
    public class FileLogger : ILogger
    {
        private readonly string _logFileName;

        public FileLogger(string logFileName)
        {
            _logFileName = logFileName;
        }

        public void Log(string message)
        {
            Console.WriteLine("Log to file {0}: {1}", _logFileName, message);
        }
    }
}
