using System;
using System.Collections.Generic;
using System.IO;

namespace register
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paths = new List<string>();
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path); 
            foreach (string fi in Directory.GetFiles(directory)) {
                if (fi.Contains("unid.exe"))
                {
                    paths.Add(fi);
                }
            }
            if (paths.ToArray().Length == 0)
            {
                Console.WriteLine("UNiD Register --> UNiD program not found in the current directory.");
            }
            else {
                try
                {
                    foreach (string fi in paths.ToArray())
                    {
                        var name = "PATH";
                        var scope = EnvironmentVariableTarget.Machine;
                        var oldValue = Environment.GetEnvironmentVariable(name, scope);
                        var newValue = oldValue + @";" + fi;
                        Environment.SetEnvironmentVariable(name, newValue, scope);
                    }
                }
                catch
                {
                    Console.WriteLine("UNiD Register --> Could not register.");
                }
            }
        }
    }
}
