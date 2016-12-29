
using AxCommandLine.Interfaces;

namespace AxCommandLine
{
    public class CommandLineOption : ICommandLineOption
    {
        public string Name { get; }
        public bool Required { get; }
        public string HelpText { get; }

        public CommandLineOption(string name, bool required, string helpText)
        {
            Name = name;
            Required = required;
            HelpText = helpText;
        }
    }
}
