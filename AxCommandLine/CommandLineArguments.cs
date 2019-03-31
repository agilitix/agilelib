using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AxCommandLine.Interfaces;

namespace AxCommandLine
{
    public class CommandLineArguments : ICommandLineArguments
    {
        #region Command line samples

        // --test=12345     --test:12345
        // -test=12345      -test:12345
        // /test=12345      /test:12345
        // --text="ab cd"   --text:"ab cd"
        // -text="ab cd"    -text:"ab cd"
        // /text="ab cd"    /text:"ab cd"

        #endregion

        private static readonly Regex _matcher = new Regex(@"^(-{1,2}|\/)(?<arg>\w+)[=:]*(?<val>.*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private readonly IDictionary<string, string> _arguments = new Dictionary<string, string>();

        public CommandLineArguments(params string[] args)
        {
            foreach (string input in args.AsEnumerable())
            {
                Match match = _matcher.Match(input);
                if (match.Success)
                {
                    string argument = match.Groups["arg"].Value;
                    string value = match.Groups["val"].Value;
                    Set(argument.Trim(), value.Trim());
                }
            }
        }

        public bool Contains(string argument)
        {
            return _arguments.ContainsKey(argument);
        }

        public int Count()
        {
            return _arguments.Count;
        }

        public void Set<T>(string argument, T value)
        {
            _arguments.Add(argument, value.ToString());
        }

        public T Get<T>(string argument)
        {
            T result;
            TryGet(argument, out result);
            return result;
        }

        public bool TryGet<T>(string argument, out T output)
        {
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
