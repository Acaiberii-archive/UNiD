using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace unid
{
    class utils
    {
        public static void Pass() { }
    }
    class admininter
    {
        [DllImport("shell32.dll")]
        internal static extern bool IsUserAnAdmin();
        public static bool Elevate(string processPath)
        {
            bool elevated = false;
            if (!IsUserAnAdmin())
            {
                elevated = true;
                ProcessStartInfo procInfo = new ProcessStartInfo(processPath);
                procInfo.UseShellExecute = true;
                procInfo.Verb = "runas";
                procInfo.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(procInfo);
            }
            return elevated;
        }
    }
    class hash
    {
        public static string CalculateMD5(string filename)
        {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        var hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
        }
    }
    class stopwatch
    {
        public static void ParseStopwatch()
        {
            long sec = 0;
            long min = 0;
            long hr = 0;
            long ms = 0;
            while (true)
            {
                Thread.Sleep(1000);
                if (sec < 60)
                {
                    sec += 1;
                    Console.WriteLine($"{hr}:{min}:{sec}");
                }
                else
                {
                    sec = 0;
                    min += 1;
                }
                if (min > 60)
                {
                    min = 0;
                    hr += 1;
                }
            }
        }
    }
}
