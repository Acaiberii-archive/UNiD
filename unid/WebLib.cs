using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace unid
{
    public static class Download
    {
        public static void ParseDownload(string[] args)
        {
            Download.DownloadFile(args[1], args[2]);
        }
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("File downloaded to " + outpath);
                Process.Start("explorer.exe", outpath);
            }
            catch (WebException er)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(er.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    public static class Upload
    {
        public static void ParseUpload(string[] args)
        {
            Upload.UploadFile(args[1], args[2]);
        }
        public static void UploadFile(string outurl, string inpath)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<------------- UNiD ------------->");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Uploading from " + inpath + " to " + outurl);
            try
            {
                WebClient downloadapi = new WebClient();
                downloadapi.UploadFile(outurl, inpath);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("File uploaded to " + outurl);
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
