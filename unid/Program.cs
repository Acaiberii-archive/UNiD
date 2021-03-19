using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace unid
{
    class Program
    {
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<------------- UNiD ------------->");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter a command -- Use help for help.");
            }
            else
            {
                if (args[0] == "help")
                {
                    DisplayHelp();
                }
                else if (args[0] == "net") {
                    if (args.Length < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<------------- UNiD ------------->");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[0] == "download")
                        {
                            if (args.Length != 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("<------------- UNiD ------------->");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Two arguments are required for the command.");
                            }
                            else
                            {
                                Download.ParseDownload(args);
                            }
                        }
                        else if (args[0] == "upload")
                        {
                            if (args.Length != 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("<------------- UNiD ------------->");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Two arguments are required for the command.");
                            }
                            else
                            {
                                Upload.ParseUpload(args);
                            }
                        }
                    }
                }
                else if (args[0] == "echo")
                {
                    OtherParsers.ParseEcho(args);
                }
                else if (args[0] == "rf")
                {
                    if (args.Length != 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<------------- UNiD ------------->");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("One argument is required for the command.");
                    }
                    else
                    {
                        readfile.ParseRF(args);
                    }
                }
                else if (args[0] == "sudo")
                {
                    if (args.Length != 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<------------- UNiD ------------->");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("One argument is required for the command.");
                    }
                    else
                    {
                        sudo.ParseSudo(args);
                    }
                }
                else if (args[0] == "file")
                {
                    if (args.Length < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<------------- UNiD ------------->");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "copy")
                        {
                            if (args.Length != 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("<------------- UNiD ------------->");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Two arguments are required for the command.");
                            }
                            else
                            {
                                copy.ParseCopy(args);
                            }
                        }
                        else if (args[1] == "remove")
                        {
                            if (args.Length != 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("<------------- UNiD ------------->");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("One argument is required for the command.");
                            }
                            else
                            {
                                remove.ParseRemove(args);
                            }
                        }
                        else if (args[1] == "hash")
                        {
                            if (args.Length != 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("<------------- UNiD ------------->");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("One argument is required for the command.");
                            }
                            else
                            {
                                if (File.Exists(args[2]))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("<------------- UNiD ------------->");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string tohash = hash.CalculateMD5(args[2]);
                                    Console.WriteLine(tohash);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("<------------- UNiD ------------->");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("The file, " + args[2] + " does not exist.");
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("<------------- UNiD ------------->");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Invalid subcommand -- Use help for help.");
                        }
                    }
                }
                else if (args[0] == "pc")
                {
                    if (args.Length < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("<------------- UNiD ------------->");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "power")
                        {
                            if (args.Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("<------------- UNiD ------------->");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("A subcommand is required.");
                            }
                            else
                            {
                                if (args[2] == "restart")
                                {
                                    Process.Start("shutdown", "/r /t 0");
                                }
                                else if (args[2] == "shutdown")
                                {
                                    Process.Start("shutdown", "/s /t 0");
                                }
                                else if (args[2] == "hibernate")
                                {
                                    SetSuspendState(true, true, false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("<------------- UNiD ------------->");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Invalid command -- Use help for help.");
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
            Console.WriteLine("net - Multiple interactions for your network. Subcommands: upload, download.");
            Console.WriteLine("echo - Echoes a given string.");
            Console.WriteLine("rf - Reads a file.");
            Console.WriteLine("sudo - Runs a program as administrator.");
            Console.WriteLine("pc - Multiple interactions for your computer. Subcommands: power - restart, shutdown, hibernate. ");
            Console.WriteLine("file - Multiple interactions for files. Subcommands: copy, remove, hash.");
        }
    }
}
