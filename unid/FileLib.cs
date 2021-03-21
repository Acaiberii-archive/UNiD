using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace unid
{
    static class file
    {
        public static class copy
        {
            public static void ParseCopy(string[] args)
            {
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
        public static class remove
        {
            public static void ParseRemove(string[] args)
            {
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
    static class dir
    {
        public static class copy
        {
            public static void ParseCopy(string[] args)
            {
                try
                {
                    foreach (string fi in Directory.GetFiles(args[2]))
                    {
                        File.Copy(fi, args[3]);
                        Console.WriteLine(fi + "was copied.");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Directory copied.");
                }
                catch (Exception er)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(er.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static class remove
        {
            public static void ParseRemove(string[] args)
            {
                try
                {
                    foreach (string fi in Directory.GetFiles(args[2]))
                    {
                        File.Delete(fi);
                    }
                    Directory.Delete(args[2]);
                }
                catch (Exception er)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(er.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static class list
        {
            public static void ParseList(string[] args)
            {
                try
                {
                    Console.WriteLine("-- Index of " + args[2] + " files.");
                    foreach (string fi in Directory.GetFiles(args[2], "*", SearchOption.AllDirectories))
                    {
                        Console.WriteLine("-" + fi + " with attributes " + File.GetAttributes(fi) + " and creation time of " + File.GetCreationTime(fi));
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
}
