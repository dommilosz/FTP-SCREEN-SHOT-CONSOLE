using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPScreenShot
{
    public partial class FTPUpload : Form
    {
        public FTPUpload()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileNames.Length + " Element(s)";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    char u = @"\".ToCharArray()[0];
                    string[] tmp = openFileDialog1.FileNames[i].Split(u);
                    ///MessageBox.Show(tmp[tmp.Length - 1]);
                    FTPHandle.UploadFile(openFileDialog1.FileNames[i], textBox2.Text, tmp[tmp.Length - 1]);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ResultsList.FromException(ex);
            }
        }
    }
}
