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
    public partial class PasswordDialog : Form
    {
        public static bool skip = true;
        string login = "dommilosz";
        string haslo = "88512";
        public static bool done = false;
        public static bool good = false;
        public PasswordDialog()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == login && textBox2.Text == haslo)
            {
                done = true;
                good = true;
                this.Close();
            }
            if (skip)
            {
                good = true;
            }
            done = true;
            this.Close();
        }
    }
}
