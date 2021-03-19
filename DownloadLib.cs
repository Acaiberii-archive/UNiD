using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace unid
{
    public class DownloadLib
    {
        public static void ParseDownload(string[] args)
        {
            List<string> argg = new List<string>();
            foreach (string arg in args)
            {
                if (arg == "download")
                {
                    utils.Pass();
                }
                else
                {
                    argg.Add(arg);
                }
            }
            Download.DownloadFile(argg[0], argg[1]);
        }
    }
    public static class Download
    {
        public static void DownloadFile(string inurl, string outpath)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<------------- UNiD ------------->");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Downloading from " + inurl + " to " + outpath);
            try
            {
                WebClient downloadapi = new WebClient();
                downloadapi.DownloadFile(inurl, outpath);
            }
            catch (WebException er)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(er.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
