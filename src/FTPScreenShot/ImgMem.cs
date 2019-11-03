using FluentFTP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;

namespace FTPScreenShot
{
    public class ImgMem
    {
        public static List<Dir> dirs = new List<Dir>();
        public static string GetHash(Dir dir)
        {
            return GetHash(dir.items);
        }
        public static string GetHash(List<FtpListItem> items)
        {
            string hash = "#";
            for (int i = 0; i < items.Count; i++)
            {
                hash += "$";
                hash += items[i].Name;
            }
            hash += "#";
            return hash;
        }
        public static void Save(List<Image> imagesa,List<FtpListItem> items, string dirname)
        {
            List<Image> imgs = new List<Image>();
            for (int i = 0; i < imagesa.Count; i++)
            {
                Image img = (Image)imagesa[i].Clone();
                imgs.Add(img);
            }
            dirs.Add(new Dir(imagesa,items, dirname));
            List<ImgMem.Dir> dirstos = ImgMem.dirs;
        }
        public static bool IsSaved(List<FtpListItem> items)
        {
            string hash = GetHash(items);
            for (int i = 0; i < dirs.Count; i++)
            {
                if (dirs[i].hash == hash) return true;
            }
            return false;
        }
        public static int SavedIndex(List<FtpListItem> items)
        {
            string hash = GetHash(items);
            for (int i = 0; i < dirs.Count; i++)
            {
                if (dirs[i].hash == hash) return i;
            }
            return -1;
        }
        public static void SaveImages()
        {
            File.WriteAllText("t.tz", dirs.ToString());
        }

        public class Dir
        {
            public readonly List<Image> images;
            public readonly List<FtpListItem> items;
            public string name;
            public string hash;
            public Dir(List<Image> imagesa, List<FtpListItem> itemsa, string name)
            {
                images = imagesa;
                items = itemsa;
                hash = ImgMem.GetHash(this);
            }
        }
        public class Img
        {
            public Dir dir;
            public Image img;
            public string name;
            public Img(Dir dira, Image imga, string nm)
            {
                dir = dira;
                img = imga;
                name = nm;
            }
        }
    }
}
