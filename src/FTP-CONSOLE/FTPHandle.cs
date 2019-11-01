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
        static string dir = "";
        static int index = 0;
        public static NetworkCredential credential = new NetworkCredential(login, haslo);
        public static FtpClient ftp = new FtpClient()
        {
            Credentials = credential,
            Host = adres
        };

        public static void FTPSend(Image img)
        {
            try
            {
                string ftpfilename = index.ToString();
                MemoryStream stream = new MemoryStream();
                stream.Position = 0;
                img.Save(stream, ImageFormat.Jpeg);
                ftp.Upload(stream, dir + "/" + ftpfilename + ".jpg");
                index++;
                ftp.Disconnect();
            }
            catch { }
        }
        public static void CreateDir(string patch = "", bool issaveloc = false)
        {
            try
            {
                ftp.CreateDirectory(patch);
                if (issaveloc) dir = patch;
                ftp.Disconnect();
            }
            catch { }
        }
        public static List<FtpListItem> GetItemsList(string patch = "")
        {
            try
            {
                List<FtpListItem> list = new List<FtpListItem>();
                if (patch != "")
                {
                    foreach (FtpListItem item in ftp.GetListing(patch))
                    {
                        list.Add(item);
                    }
                    ftp.Disconnect();
                    return list;
                }
                foreach (FtpListItem item in ftp.GetListing())
                {
                    list.Add(item);
                }
                ftp.Disconnect();
                return list;
            }
            catch { }
            return null;
        }
        public static Image DownloadImage(string patch)
        {
            try
            {
                Image img;
                MemoryStream stream = new MemoryStream();
                ftp.Download(stream, patch);
                img = Image.FromStream(stream);
                ftp.Disconnect();
                return img;
            }
            catch { }
            return null;
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
    } }
