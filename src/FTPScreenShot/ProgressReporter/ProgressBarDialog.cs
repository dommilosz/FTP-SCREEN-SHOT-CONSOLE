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
    public partial class ProgressBarDialog : Form
    {
        public ProgressBarDialog()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                this.Close();
            }
        }

        private void ProgressBarDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
