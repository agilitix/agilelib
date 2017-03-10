using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AxCommandLine.Interfaces;

namespace AxCommandLine
{
    public class CommandLineArguments : ICommandLineArguments
    {
        private static readonly Regex _matcher = new Regex(@"^(-{1,2}|\/)(?<option>\w+)[=:]*(?<value>.*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private readonly IDictionary<string, string> _arguments = new Dictionary<string, string>();

        public CommandLineArguments(params string[] args)
        {
            foreach (string input in args.AsEnumerable())
            {
                Match match = _matcher.Match(input);
                if (match.Success)
                {
                    string option = match.Groups["option"].Value;
                    string value = match.Groups["value"].Value;
                    if (string.IsNullOrEmpty(value))
                    {
                        value = "true";
                    }
                    Set(option, value);
                }
            }
        }

        public void Set(string argument, string value)
        {
            _arguments.Add(argument.ToLower(), value);
        }

        public bool Contains(string argument)
        {
            return _arguments.ContainsKey(argument.ToLower());
        }

        public int Count()
        {
            return _arguments.Count;
        }

        public T Get<T>(string argument)
        {
            T result;
            TryGet(argument, out result);
            return result;
        }

        public bool TryGet<T>(string argument, out T output)
        {
            argument = argument.ToLower();
            if (_arguments.ContainsKey(argument))
            {
                output = (T) Convert.ChangeType(_arguments[argument], typeof(T));
                return true;
            }

            output = default(T);
            return false;
        }

        public override string ToString()
        {
            return string.Join(" ", _arguments.Select(x => x.Key + "=\"" + x.Value + "\""));
        }
    }
}
