using FluentFTP;
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
                patch = "ScreenShot/" + index.ToString();
            if (name != "{auto}")
                patch = "ScreenShot/" + name;
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
            ftp.CreateDirectory(patch);
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
                    Program.WriteTxt("&eListing : " + patch2);
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
                ftp.CreateDirectory("ScreenShot/" + dirname);
                ftp.UploadFile(localpatch, "ScreenShot/" + dirname + "/" + filename);
                ftp.Disconnect();
            }
            catch { }
        }

        public static void FTPDelete(string patch)
        {

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
    }
}
