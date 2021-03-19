using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace unid
{
    static class copy
    {
        public static void ParseCopy(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<------------- UNiD ------------->");
            try
            {
                File.Copy(args[2], args[3]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("File copied.");
            }
            catch (Exception er)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(er.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    static class remove
    {
        public static void ParseRemove(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<------------- UNiD ------------->");
            try
            {
                if (File.Exists(args[2]))
                {
                    Console.WriteLine("Deleting file " + args[2] + "...");
                    File.Delete(args[2]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("File deleted.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The file, " + args[2] + " does not exist.");
                    Console.ForegroundColor = ConsoleColor.White;
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
