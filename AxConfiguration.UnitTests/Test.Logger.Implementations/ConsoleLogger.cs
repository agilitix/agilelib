using System;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;

namespace AxConfiguration.UnitTests.Test.Logger.Implementations
{
    internal class ConsoleLogger : ILogger
    {
        public string LoggerName { get; private set; }

        public ConsoleLogger(string loggerName)
        {
            LoggerName = loggerName;
        }

        public void Log(string message)
        {
            Console.WriteLine("LoggerName={0} : {1}", LoggerName, message);
        }
    }
}