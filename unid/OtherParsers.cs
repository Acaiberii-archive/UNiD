using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            Console.WriteLine(ar);
        }
        public static void ParseTypewrite(string[] args)
        {
            args[0] = string.Empty;
            string ar = string.Empty;
            foreach (string arg in args)
            {
                ar += arg + " ";
            }
            foreach (char ch in ar)
            {
                Thread.Sleep(100);
                Console.Write(ch);
            }
            Console.Write("\n");
        }
    }
    class readfile
    {
        public static void ParseRF(string[] args)
        {
            try
            {
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
