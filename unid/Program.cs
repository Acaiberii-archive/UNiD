using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace unid
{
    class Program
    {
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<=------------- UNiD Console -------------=>");
            Console.ForegroundColor = ConsoleColor.White;
            if (args.Length == 0)
            {
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
                                WebClient downloadapi = new WebClient();
                                string user = "";
                                foreach (string dir in Directory.GetDirectories(@"C:\Users\"))
                                {
                                    if (dir.Contains(Environment.UserName))
                                    {
                                        user = dir;
                                    }
                                }
                                if (Directory.Exists(user + @"\UNiDPackages"))
                                {
                                    Console.WriteLine("Directory exists. Selecting package.");
                                    if (args[2] == "py")
                                    {
                                        if (File.Exists(user + @"\UNiDPackages\python.exe"))
                                        {
                                            Console.WriteLine("Overwriting your previous Python installation. Don't worry, as this won't remove a previous version.");
                                            File.Delete(user + @"\UNiDPackages\python.exe");
                                        }
                                        else
                                        {
                                            downloadapi.DownloadFile("https://www.python.org/ftp/python/3.9.2/python-3.9.2.exe", user + @"\UNiDPackages\python.exe");
                                            Process.Start(user + @"\UNiDPackages\python.exe");
                                            Console.WriteLine("Python installed.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Unknown package. Try again, or use the list subcommand.");
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        Directory.CreateDirectory(user + @"\UNiDPackages");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("User information verified and directory created. Please retype the command.");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("You won't have to do this again unless you switch accounts.");
                                        Console.ForegroundColor = ConsoleColor.White;
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
                        else if (args[1] == "list")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(">==->==->==- Packages");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("py - Python 3.9.2 (latest release as of 3/20/21)");
                        }
                        else
                        {
                            Console.WriteLine("Invalid subcommand -- Use help for help.");
                        }
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
            Console.WriteLine("sudo - Runs a program as administrator.");
            Console.WriteLine("pc - Multiple interactions for your computer. Subcommands: power - restart, shutdown, hibernate. ");
            Console.WriteLine("file - Multiple interactions for files. Subcommands: copy, remove, hash.");
            Console.WriteLine("dir - Multiple interactions for directories. Subcommands: copy, remove, list.");
            Console.WriteLine("theme - Changes the command line's theme. Subcommands: bright, dark, dracula.");
            Console.WriteLine("typewrite - Types a given string with delay between each character.");
            Console.WriteLine("package - Installs packages. Subcommands: install, list.");
        }
    }
}
