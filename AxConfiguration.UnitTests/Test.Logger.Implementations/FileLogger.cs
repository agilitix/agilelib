using System;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;

namespace AxConfiguration.UnitTests.Test.Logger.Implementations
{
    public class FileLogger : ILogger
    {
        private readonly string _logFileName;
        private readonly string _timeStampFormat;

        public string LoggerName { get; private set; }

        public FileLogger(string loggerName, string logFileName, string timeStampFormat)
        {
            LoggerName = loggerName;
            _logFileName = logFileName;
            _timeStampFormat = timeStampFormat;
        }

        public void Log(string message)
        {
            Console.WriteLine("LoggerName={0} File={1}: {2} {3}",
                              LoggerName,
                              _logFileName,
                              DateTime.Now.ToString(_timeStampFormat),
                              message);
        }
    }
}