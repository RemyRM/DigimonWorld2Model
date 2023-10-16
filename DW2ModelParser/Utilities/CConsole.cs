using System;

namespace DW2ModelParser.Utilities
{
    internal class CConsole
    {
        public static void WriteLineColoured(string msg, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
