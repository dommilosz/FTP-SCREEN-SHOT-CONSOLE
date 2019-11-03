using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPScreenShot
{
    public static class ImageString
    {
        public static string ToString(this Image image)
        {
            if (image == null)
                return String.Empty;

            var stream = new MemoryStream();
            image.Save(stream, image.RawFormat);
            var bytes = stream.ToArray();

            return Convert.ToBase64String(bytes);
        }
        public static Image ToImage(this string base64String)
        {
            if (String.IsNullOrWhiteSpace(base64String))
                return null;

            var bytes = Convert.FromBase64String(base64String);
            var stream = new MemoryStream(bytes);
            return Image.FromStream(stream);
        }
        public class Save
        {
            static string dirseparator = "^";
            static string imgseparator = "$";
            static string imgdatasep = "#";
            public static void SaveFile(List<ImgMem.Dir> dirs)
            {

            }
            public static List<ImgMem.Dir> LoadFile()
            {
                return null;
            }
        }
    }
   
}
