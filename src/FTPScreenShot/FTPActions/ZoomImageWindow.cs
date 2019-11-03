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
    public partial class ZoomImageWindow : Form
    {
        public ZoomImageWindow()
        {
            InitializeComponent();
        }
        public ZoomImageWindow(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = img;
        }

        private void ZoomImageWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
