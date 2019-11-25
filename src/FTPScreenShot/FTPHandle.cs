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
using System.Windows.Forms;

namespace FTPScreenShot
{
    class FTPHandle
    {
        public static string login = "screenshotftp@screenshotftp.cba.pl";
        public static string haslo = "ej5W83QjJHHXaaJB";
        public static string adres = "ftp://www.mkwk018.cba.pl";
        public static string adresfactory = "ftp://www.mkwk018.cba.pl";
        static string dir = "";
        static int index = 0;
        public static NetworkCredential credential = new NetworkCredential(login, haslo);

        public static void FTPSend(Image img)
        {
            try
            {
                string ftpfilename = index.ToString();
                FtpClient ftp = new FtpClient(adres, credential);
                MemoryStream stream = new MemoryStream();
                stream.Position = 0;
                img.Save(stream, ImageFormat.Jpeg);
                ftp.Upload(stream, dir + "/" + ftpfilename + ".jpg");
                index++;
                ftp.Disconnect();
            }
            catch (Exception ex) { ResultsList.FromException(ex); }
        }
        public static void CreateDir(string patch = "", bool issaveloc = false)
        {
            try
            {
                FtpClient ftp = new FtpClient(adres, credential);
                ftp.CreateDirectory(patch);
                if (issaveloc) dir = patch;
                ftp.Disconnect();
            }
            catch (Exception ex) { ResultsList.FromException(ex); }
        }
        public static List<FtpListItem> GetItemsList(string patch = "")
        {
            try
            {
                List<FtpListItem> list = new List<FtpListItem>();
                FtpClient ftp = new FtpClient(adres, credential);
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
            catch (Exception ex) { ResultsList.FromException(ex); }
            return null;
        }
        public static Image DownloadImage(string patch)
        {
            try
            {
                Image img;
                FtpClient ftp = new FtpClient(adres, credential);
                MemoryStream stream = new MemoryStream();
                ftp.Download(stream, patch);
                img = Image.FromStream(stream);
                ftp.Disconnect();
                return img;
            }
            catch (Exception ex) { ResultsList.FromException(ex); }
            return null;
        }

        public static void UploadFile(string localpatch, string dirname, string filename)
        {
            try
            {
                FtpClient ftp = new FtpClient(adres, credential);
                ftp.CreateDirectory("ScreenShot/" + dirname);
                ftp.UploadFile(localpatch, "ScreenShot/" + dirname + "/" + filename);
                ftp.Disconnect();
            }
            catch (Exception ex) { ResultsList.FromException(ex); }
        }

        public static void FTPDelete(string patch)
        {
            try
            {
                FtpClient ftp = new FtpClient(adres, credential);
                ftp.DeleteDirectory(patch);
                ftp.Disconnect();
            }
            catch
            {
                try
                {
                    FtpClient ftp = new FtpClient(adres, credential);
                    ftp.DeleteFile(patch);
                    ftp.Disconnect();
                }
                catch (Exception ex) { ResultsList.FromException(ex); }
            }
        }
    }
}
