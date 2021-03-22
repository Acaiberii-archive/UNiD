using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace unid
{
    class Program
    {
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<=------------- UNiD -------------=>");
            Console.ForegroundColor = ConsoleColor.White;
            if (args.Length < 1)
            {
                Console.WriteLine("Please enter a command -- Use help for help.");
            }
            else
            {
                Console.Title = $"UNiD CMD - Parsing command {args[0]}.";
                if (args[0] == "help")
                {
                    DisplayHelp();
                }
                else if (args[0] == "net") {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "download")
                        {
                            if (args.Length < 4)
                            {
                                Console.WriteLine("Two arguments are required for the command.");
                            }
                            else
                            {
                                Download.ParseDownload(args);
                            }
                        }
                        else if (args[1] == "upload")
                        {
                            if (args.Length < 4)
                            {
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
                    if (args.Length < 2)
                    {
                        Console.WriteLine("One argument is required for the command.");
                    }
                    else
                    {
                        readfile.ParseRF(args);
                    }
                }
                else if (args[0] == "sudo")
                {
                    if (args.Length < 2)
                    {
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
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "copy")
                        {
                            if (args.Length != 4)
                            {
                                Console.WriteLine("Two arguments are required for the command.");
                            }
                            else
                            {
                                file.copy.ParseCopy(args);
                            }
                        }
                        else if (args[1] == "remove")
                        {
                            if (args.Length != 3)
                            {
                                Console.WriteLine("One argument is required for the command.");
                            }
                            else
                            {
                                file.remove.ParseRemove(args);
                            }
                        }
                        else if (args[1] == "info")
                        {
                            if (args.Length != 3) {
                                Console.WriteLine("One argument is required for the command.");
                            }
                            else {
                                Console.WriteLine($"File path: {args[2]}");
                                Console.WriteLine($"File creation date: {File.GetCreationTime(args[2])}");
                                Console.WriteLine($"Last accessed: {File.GetLastAccessTime(args[2])}");
                                Console.WriteLine($"File hash: {hash.CalculateMD5(args[2])}");
                            }
                        }
                        else if (args[1] == "hash")
                        {
                            if (args.Length != 3)
                            {
                                Console.WriteLine("One argument is required for the command.");
                            }
                            else
                            {
                                if (File.Exists(args[2]))
                                {
                                    string tohash = hash.CalculateMD5(args[2]);
                                    Console.WriteLine(tohash);
                                }
                                else
                                {
                                    Console.WriteLine("The file, " + args[2] + " does not exist.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid subcommand -- Use help for help.");
                        }
                    }
                }
                else if (args[0] == "pc")
                {
                    if (args.Length < 2)
                    {



                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "power")
                        {
                            if (args.Length < 3)
                            {
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
                else if (args[0] == "dir")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "copy")
                        {
                            if (args.Length != 4)
                            {
                                Console.WriteLine("Two arguments are required for the command.");
                            }
                            else
                            {
                                dir.copy.ParseCopy(args);
                            }
                        }
                        else if (args[1] == "remove")
                        {
                            if (args.Length != 3)
                            {
                                Console.WriteLine("One argument is required for the command.");
                            }
                            else
                            {
                                dir.remove.ParseRemove(args);
                            }
                        }
                        else if (args[1] == "list")
                        {
                            if (args.Length != 3)
                            {
                                Console.WriteLine("One argument is required for the command.");
                            }
                            else
                            {
                                dir.list.ParseList(args);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid subcommand -- Use help for help.");
                        }
                    }
                }
                else if (args[0] == "theme")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("One argument is required for the command.");
                    }
                    else
                    {
                        if (args[1] == "bright")
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else if (args[1] == "dark")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (args[1] == "dracula")
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                else if (args[0] == "typewrite")
                {
                    OtherParsers.ParseTypewrite(args);
                }
                else if (args[0] == "package")
                {
                    Console.WriteLine("<=----- Unid Package Manager -----=>");
                    if (args.Length < 2)
                    {
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "install")
                        {
                            if (args.Length < 3)
                            {
                                Console.WriteLine("One argument is required for the command.");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.ForegroundColor = ConsoleColor.White;
                                pkg.ParsePkg(args);
                            }
                        }
                        else if (args[1] == "list")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(">==->==->==- Packages");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("py - Python 3.9.2 (latest release as of 3/20/21)");
                            Console.WriteLine("java - Java 8 (recommended release on java.com)");
                        }
                        else
                        {
                            Console.WriteLine("Invalid subcommand -- Use help for help.");
                        }
                    }
                }
                else if (args[0] == "about")
                {
                    test.ParseTest();
                }
                else if (args[0] == "test")
                {
                    try
                    {
                        Console.WriteLine("-- The console's interface and UNiD are working correctly.");
                        Console.WriteLine($"- Console input stream type: {Console.In.ToString()}");
                        Console.WriteLine($"- Console output stream type: {Console.Out.ToString()}");
                        Console.WriteLine($"- Console error stream type: {Console.Error.ToString()}");
                        Console.WriteLine($"- Console foreground/background: {Console.ForegroundColor.ToString()}/{Console.BackgroundColor.ToString()}");
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine("-- The console may not be working properly.");
                        Console.WriteLine($"- Exception: {er.Message}. Try restarting the command prompt or submitting an issue at https://www.github.com/AcaiBerii/UNiD");
                        Console.Beep();
                    }
                }
                else if (args[0] == "tf")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("One argument is required for the command.");
                    }
                    else
                    {
                        foreach (char c in new StreamReader(args[1]).ReadToEnd())
                        {
                            System.Threading.Thread.Sleep(100);
                            Console.Write(c);
                        }
                        Console.WriteLine("");
                    }
                }
                else if (args[0] == "debug")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "error")
                        {
                            throw new ErrorToThrow();
                        }
                        else if (args[1] == "web")
                        {
                            WebClient wr = new WebClient();
                            try
                            {
                                string wres = wr.DownloadString("https://www.example.com");
                                Console.WriteLine(wr);
                                Console.WriteLine("Request OK");
                            }
                            catch (Exception er) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(er.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                if (er.Message.ToLower().Contains("no such host is known"))
                                {
                                    Console.WriteLine("UNiD Debug Err 01: No connection to example.com available.");
                                    Console.WriteLine("Please check your internet connection.");
                                }
                                Console.Beep();
                            }
                        } 
                        else
                        {
                            Console.WriteLine("Invalid subcommand -- Use help for help.");
                        }
                    }
                }
                else if (args[0] == "stopwatch")
                {
                    Console.Clear();
                    stopwatch.ParseStopwatch();
                }
                else if (args[0] == "fun")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("A subcommand is required.");
                    }
                    else
                    {
                        if (args[1] == "rainbow")
                        {
                            test.ParseRainbow();
                        }
                    }
                }
                else if (args[0] == "kill")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("One argument is required for the command.");
                    }
                    else
                    {
                        args[0] = string.Empty;
                        string argg = string.Empty;
                        foreach (string arg in args)
                        {
                            argg += arg;
                        }
                        if (argg.StartsWith(" "))
                        {
                            argg = argg.Substring(1);
                        }
                        foreach (System.Diagnostics.Process pr in System.Diagnostics.Process.GetProcesses())
                        {
                            try
                            {
                                if (pr.ProcessName.Contains(argg))
                                {
                                    pr.Kill();
                                }
                            }
                            catch (Exception er)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(er.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        Console.WriteLine("Attempted to find and kill program with name containing " + argg + ".");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command -- Use help for help.");
                }

            }
        }
        static void DisplayHelp()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(">==->==->==- Commands");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("help - Displays help page.");
            Console.WriteLine("net - Multiple interactions for your network. Subcommands: upload, download.");
            Console.WriteLine("echo - Echoes a given string.");
            Console.WriteLine("rf - Reads a file.");
            Console.WriteLine("tf - Typewrites a file.");
            Console.WriteLine("typewrite - Types a given string with delay between each character.");
            Console.WriteLine("sudo - Runs a program as administrator.");
            Console.WriteLine("pc - Multiple interactions for your computer. Subcommands: power - restart, shutdown, hibernate. ");
            Console.WriteLine("file - Multiple interactions for files. Subcommands: copy, remove, hash.");
            Console.WriteLine("dir - Multiple interactions for directories. Subcommands: copy, remove, list.");
            Console.WriteLine("theme - Changes the command line's theme. Subcommands: bright, dark, dracula.");
            Console.WriteLine("package - Installs packages. Subcommands: install, list.");
            Console.WriteLine("about - Shows information about UNiD.");
            Console.WriteLine("debug - Commands to debug UNiD with. Subcommands: error, web.");
            Console.WriteLine("kill - Kills a process based on the given argument.");
            Console.WriteLine("fun - A collection of funny commands. Subcommands: rainbow.");
        }
    }
    class ErrorToThrow : Exception
    {
        public ErrorToThrow() {
            throw new ErrorToThrow();
        }
    }
}