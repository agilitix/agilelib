using System;

namespace AxUtils
{
    public class ConsoleExitHandler
    {
        protected ConsoleExitHandler()
        {
        }

        public static void Setup()
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
