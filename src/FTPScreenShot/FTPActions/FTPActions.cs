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
    public partial class FTPActions : Form
    {
        public FTPActions()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FTPExplorer exp = new FTPExplorer();
            exp.ShowDialog();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FTPUpload upl = new FTPUpload();
            upl.ShowDialog();
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FTPDelete del = new FTPDelete();
            del.ShowDialog();
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Tree t = new Tree();
            t.ShowDialog();
            this.Close();
        }
    }
}
