using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

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
}
