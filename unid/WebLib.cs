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
            Download.DownloadFile(args[2], args[3]);
        }
        public static void DownloadFile(string inurl, string outpath)
        {
            Console.WriteLine("Downloading from " + inurl + " to " + outpath);
            try
            {
                WebClient downloadapi = new WebClient();
                downloadapi.DownloadFile(inurl, outpath);
                Console.ResetColor();
                Console.WriteLine("File downloaded to " + outpath);
                Process.Start("explorer.exe", outpath);
            }
            catch (Exception er)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(er.Message);
                Console.ResetColor();
            }
        }
    }
    public static class Upload
    {
        public static void ParseUpload(string[] args)
        {
            Upload.UploadFile(args[2], args[3]);
        }
        public static void UploadFile(string outurl, string inpath)
        {
            Console.WriteLine("Uploading from " + inpath + " to " + outurl);
            try
            {
                WebClient downloadapi = new WebClient();
                downloadapi.UploadFile(outurl, inpath);
                Console.ResetColor();
                Console.WriteLine("File uploaded to " + outurl);
            }
            catch (Exception er)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(er.Message);
                Console.ResetColor();
            }
        }
    }
}
