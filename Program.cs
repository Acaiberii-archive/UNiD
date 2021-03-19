using System;
using System.Collections.Generic;

namespace unid
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<------------- UNiD ------------->");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter an argument -- Use /? for help.");
            }
            else
            {
                if (args[0] == "help")
                {
                    DisplayHelp();
                }
                else if (args[0] == "download")
                {
                    if (args[1] == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<------------- UNiD ------------->");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("An argument is required for the command download (URL required).");
                    }
                    else
                    {
                        DownloadLib.ParseDownload(args);
                    }
                }
            }
        }
        static void DisplayHelp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<------------- UNiD Help ------------->");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(">>-- Commands");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("help - Displays help page.");
            Console.WriteLine("download - Downloads a file.");
        }
        
    }
}
