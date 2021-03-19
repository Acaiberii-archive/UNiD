using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace unid
{
    class OtherParsers
    {
        public static void ParseEcho(string[] args) {
            args[0] = string.Empty;
            string ar = string.Empty;
            foreach (string arg in args)
            {
                ar += arg + " ";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<------------- UNiD ------------->");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ar);
        }
    }
    class readfile
    {
        public static void ParseRF(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<------------- UNiD ------------->");
                Console.ForegroundColor = ConsoleColor.White;
                StreamReader rflib = new StreamReader(args[1]);
                string thefile = rflib.ReadToEnd();
                Console.WriteLine(thefile);
            }
            catch (Exception er)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(er.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    class sudo
    {
        public static void ParseSudo(string[] args)
        {
            args[0] = string.Empty;
            string cm = string.Empty;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<------------- UNiD ------------->");
            foreach (string arg in args)
            {
                cm += arg;
            }
            try
            {
                bool isrunning = admininter.Elevate(cm);
                if (isrunning == true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Elevated program.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Could not elevate program.");
                }
            }
            catch (Exception er)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(er.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
