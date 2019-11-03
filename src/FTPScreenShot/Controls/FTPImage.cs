using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPScreenShot.Controls
{
    public partial class FTPImage : UserControl
    {
        public FTPImage()
        {
            InitializeComponent();
        }

        int index = 0;
        int page = 1;
        List<FtpListItem> dirs;
        List<FtpListItem> imagesindir;
        public List<Image> images = new List<Image>();

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartGetImages();
        }
        private void StartGetImages()
        {
            ProgressReport.StartReporting();
            dirs = GetItems(true);
            GetFiles(dirs);
            SetImages();
        }

        public void SetImages()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            try { pictureBox1.Image = images[(page - 1) * 8]; } catch { }
            try { pictureBox2.Image = images[((page - 1) * 8) + 1]; } catch { }
            try { pictureBox3.Image = images[((page - 1) * 8) + 2]; } catch { }
            try { pictureBox4.Image = images[((page - 1) * 8) + 3]; } catch { }
            try { pictureBox5.Image = images[((page - 1) * 8) + 4]; } catch { }
            try { pictureBox6.Image = images[((page - 1) * 8) + 5]; } catch { }
            try { pictureBox7.Image = images[((page - 1) * 8) + 6]; } catch { }
            try { pictureBox8.Image = images[((page - 1) * 8) + 7]; } catch { }
        }

        public List<FtpListItem> GetItems(bool changecombobox = false)
        {
            if (comboBox1.SelectedIndex >= 0)
                index = comboBox1.SelectedIndex;
            if (changecombobox) comboBox1.Items.Clear();
            //if (changecombobox) comboBox1.Items.Add("Select Dir");
            List<FtpListItem> dirs = FTPHandle.GetItemsList("/ScreenShot");
            for (int i = 0; i < dirs.Count; i++)
            {
                if (changecombobox) comboBox1.Items.Add(dirs[i].Name + "   ||    Count : " + FTPHandle.GetItemsList(dirs[i].FullName).Count);
            }
            //if (changecombobox) comboBox1.SelectedIndex = 0;
            return dirs;
        }
        private void GetFiles(List<FtpListItem> dirs)
        {
            imagesindir = FTPHandle.GetItemsList(dirs[index].FullName);
            int max = imagesindir.Count;
            this.images = new List<Image>();
            if (2==1)
            {
                for (int i = 0; i < max; i++)
                {
                    try
                    {
                        images.Add(FTPHandle.DownloadImage(imagesindir[i].FullName));
                        ProgressReport.Report(i + 1, max);
                    }
                    catch (Exception ex) { i = 100000; ResultsList.FromException(ex); }
                }
            }
            else
            {
                if (ImgMem.IsSaved(imagesindir))
                {
                    List<ImgMem.Dir> dirstos = ImgMem.dirs;
                    ImgMem.Dir dir = ImgMem.dirs[ImgMem.SavedIndex(imagesindir)];
                    images = dir.images;
                    ProgressReport.Report(1,1);
                    SetImages();
                }
                else
                {
                    for (int i = 0; i < max; i++)
                    {
                        try
                        {
                            images.Add(FTPHandle.DownloadImage(imagesindir[i].FullName));
                            ProgressReport.Report(i + 1, max);
                        }
                        catch (Exception ex) { i = 100000; ResultsList.FromException(ex); }
                    }
                    ImgMem.Save(images, imagesindir, dirs[index].Name);
                    
                }
                ImgMem.SaveImages();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (images.Count >= ((page) * 8) - 1)
            {
                page++;
                try { SetImages(); } catch { page--; }
                textBox1.Text = page.ToString();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                try { SetImages(); } catch { page++; }
                textBox1.Text = page.ToString();
            }
        }

        private void ZoomImage(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            ZoomImageWindow zoomImage = new ZoomImageWindow(pictureBox.Image);
            zoomImage.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string downloaddir = Application.StartupPath + "/Download/" + dirs[index].Name.Replace(':', '.');
                string filedir;
                try
                {
                    Directory.CreateDirectory(downloaddir);
                }
                catch { }
                for (int i = 0; i < images.Count; i++)
                {
                    filedir = downloaddir + "/" + imagesindir[i].Name.Replace(':', '.');
                    images[i].Save(filedir);
                }
                MessageBox.Show("Saved to : " + downloaddir);
            }
            catch (Exception ex)
            {
                ResultsList.FromException(ex);
            }
        }
    }
}
