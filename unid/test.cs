using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace unid
{
    class test
    {
        public static void ParseTest()
        {
            Console.WriteLine("{}       {}  {}{}     {}  {}{}{}{}{}{}  {}{}{}{}");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("{}       {}  {}  {}   {}       {}       {}      {}");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("{}       {}  {}    {} {}       {}       {}      {}");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("  {}{}{}{}   {}       {}  {}{}{}{}{}{}  {}{}{}{}");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("UNiD 1.1 - UNiD by AcaiBerii/SumWhatSteve.");
            Console.WriteLine("UNiD, the open-source command line utility and package manager.");
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
        }
        public static void ParseRainbow()
        {
            while (true)
            {
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.WriteLine("Fun!");
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Clear();
                Console.WriteLine("Fun!");
            }
        }
        public static void ParseASCII(string[] args)
        {
            string tourl = string.Empty;
            args[0] = string.Empty;
            args[1] = string.Empty;
            foreach (string arg in args)
            {
                tourl += arg;
            }
            if (tourl.StartsWith("  ")) {
                tourl = tourl.Substring(2);
            }
            else if (tourl.StartsWith(" "))
            {
                tourl = tourl.Substring(1);
            }
            tourl = tourl.Replace(" ", "+");
            string html = string.Empty;
            string url = $@"https://artii.herokuapp.com/make?text={tourl}&font=thin";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            Console.Write(html);
        }
    }
}
