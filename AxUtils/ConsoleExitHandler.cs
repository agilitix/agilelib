using System;

namespace AxUtils
{
    public class ConsoleExitHandler
    {
        public ConsoleExitHandler()
        {
            Console.TreatControlCAsInput = false;
            Console.CancelKeyPress += (snd, evt) =>
                                      {
                                          Console.WriteLine("Ctrl+C pressed");
                                          evt.Cancel = true;
                                      };
        }
    }
}
