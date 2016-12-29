using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxCommandLine.Interfaces;

namespace AxCommandLine
{
    public class CommandLineValidator : ICommandLineValidator
    {
        private readonly IList<ICommandLineOption> _options = new List<ICommandLineOption>();
        private readonly ICommandLineArguments _arguments;

        public virtual string Usage
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (ICommandLineOption option in _options)
                {
                    sb.Append(option.HelpText);
                    sb.Append("\n");
                }

                return sb.ToString();
            }
        }

        public CommandLineValidator(ICommandLineArguments arguments)
        {
            _arguments = arguments;
        }

        public virtual bool Validate()
        {
            return _options.All(option => option.Required && _arguments.Contains(option.Name));
        }

        public void AddOption(ICommandLineOption option)
        {
            _options.Add(option);
        }
    }
}
