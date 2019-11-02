﻿using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_CONSOLE
{
    public static class FTPHandle
    {
        public static string login = "screenshotftp@screenshotftp.cba.pl";
        public static string haslo = "ej5W83QjJHHXaaJB";
        public static string adres = "ftp://www.mkwk018.cba.pl";
        public static string adresfactory = "ftp://www.mkwk018.cba.pl";
        static string dir = "ScreenShot";
        static int index = 0;
        public static NetworkCredential credential = new NetworkCredential(login, haslo);
        public static FtpClient ftp = new FtpClient()
        {
            Credentials = credential,
            Host = adres
        };

        public static void FTPSend(Image img, string name = "{auto}")
        {
            string patch = "";

            ftp.Connect();
            if (name == "{auto}")
                patch = "0RootScreenShot08/" + index.ToString();
            if (name != "{auto}")
                patch = name;
            patch += ".jpg";
            MemoryStream stream = new MemoryStream();
            stream.Position = 0;
            img.Save(stream, ImageFormat.Jpeg);

            List<string> dirs = patch.Split('/').ToList();
            for (int i = 0; i < dirs.Count - 1; i++)
            {
                string ddir = Program.GetArgs(dirs, 0, i, "/");
                if (!ftp.DirectoryExists(ddir)) CreateDir(ddir);
            }

            ftp.Upload(stream, patch);
            index++;
            ftp.Disconnect();


        }
        public static void CreateDir(string patch = "", bool issaveloc = false)
        {


            ftp.Connect();
            if (!ftp.DirectoryExists(patch))
            {
                Program.WriteTxt("&eCreating dir : " + patch);
                ftp.CreateDirectory(patch);
            }
            if (issaveloc) dir = patch;
            ftp.Disconnect();


        }
        public static List<FtpListItem> GetItemsList(string patch = "")
        {
            List<FtpListItem> GetList(string patch2, List<FtpListItem> list2)
            {
                foreach (FtpListItem item in ftp.GetListing(patch2))
                {


                    list2.Add(item);
                    Program.WriteTxt("&eListing : " + patch2.Replace("0RootScreenShot08/", ""));
                    if (item.Type == FtpFileSystemObjectType.Directory)
                        GetList(item.FullName, list2);

                }
                return list2;
            }
            List<FtpListItem> list = new List<FtpListItem>();
            return GetList(patch, list);
        }
        public static Image DownloadImage(string patch)
        {

            Image img;
            MemoryStream stream = new MemoryStream();
            ftp.Download(stream, patch);
            img = Image.FromStream(stream);
            ftp.Disconnect();
            return img;
        }

        public static void UploadFile(string localpatch, string dirname, string filename)
        {
            try
            {
                ftp.CreateDirectory("0RootScreenShot08/" + dirname);
                ftp.UploadFile(localpatch, "0RootScreenShot08/" + dirname + "/" + filename);
                ftp.Disconnect();
            }
            catch { }
        }

        public static void FTPDelete(string patch)
        {
            if (patch.Length > 18)
            {
                if (patch[18] == '*') Program.WriteTxt($"&4Do You Want To Delete : EVERYTHING? &aY/N");
                else
                    Program.WriteTxt($"&4Do You Want To Delete : {patch}? &aY/N");
            }
            else throw new Exception("Patch can not be null");



            if (Console.ReadKey().KeyChar == 'Y' || Console.ReadKey().KeyChar == 'y')
            {
                Console.WriteLine("");
                var items = GetItemsList(patch);
                for (int i = items.Count - 1; i >= 0; i--)
                {
                    var item = items[i];
                    if (item.Type == FtpFileSystemObjectType.Directory)
                    {
                        Program.WriteTxt("&eDeleting dir : " + item.FullName);
                        ftp.DeleteDirectory(item.FullName);
                    }
                    if (item.Type == FtpFileSystemObjectType.File)
                    {
                        Program.WriteTxt("&eDeleting file : " + item.FullName);
                        ftp.DeleteFile(item.FullName);
                    }
                }
                foreach (var item in GetItemsList(patch))
                {

                }
                ftp.DeleteDirectory(patch);
            }
            else Program.WriteTxt("");
        }
        public static void ResetToFactory()
        {
            credential = new NetworkCredential(login, haslo);
            adres = adresfactory;
            ReloadCredentials();
        }
        public static void ReloadCredentials()
        {
            ftp.Credentials = credential;
            ftp.Host = adres;
        }
        public static void DownloadAll(List<FtpListItem> list)
        {
            foreach (var item in list)
            {
                string patch = $"{Application.StartupPath}{@"\"}Downloads{item.FullName.Replace(@":", "-")}".Replace("/", @"\"); ;
                List<string> dirs = patch.Split(@"\"[0]).ToList();
                for (int i = 0; i < dirs.Count - 1; i++)
                {
                    string ddir = Program.GetArgs(dirs, 0, i, @"\").TrimEnd(@"\"[0]);
                    ddir = ddir;
                    if (!Directory.Exists(ddir))
                        Directory.CreateDirectory(ddir);
                }

                if (item.Type == FtpFileSystemObjectType.File)
                {
                    Program.WriteTxt("&eDeleting file : " + item.FullName.Trim('/'));
                    ftp.DownloadFile(patch, item.FullName.Trim('/'));
                }
            }
        }
    }
}
