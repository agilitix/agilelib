using System;
using AxConfiguration.UnitTests.Test.Logger.Interfaces;

namespace AxConfiguration.UnitTests.Test.Logger.Implementations
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Log to console: " + message);
        }
    }
}