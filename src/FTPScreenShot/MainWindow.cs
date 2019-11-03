using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WikipediaNet;
using WikipediaNet.Objects;

namespace FTPScreenShot
{
    public partial class MainWindow : Form
    {
        public static MainWindow form1;
        bool folder_created = false;
        public bool newconsole = true;
        public MainWindow()
        {
            InitializeComponent();
            form1 = this;
            
            PasswordDialog pd = new PasswordDialog();
            pd.ShowDialog();
            FTPHandle.CreateDir("ScreenShot/");

        }
        public MainWindow(bool nopass)
        {
            InitializeComponent();
            form1 = this;
            if (!nopass)
            {
                PasswordDialog pd = new PasswordDialog();
                pd.ShowDialog();
            }
            FTPHandle.CreateDir("ScreenShot/");

        }

        public void AcceptLogin()
        {
            timer1.Stop();
        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            if (PasswordDialog.done && !PasswordDialog.good)
            {
                this.Close();
            }
            if (PasswordDialog.good) timer1.Stop();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                this.Visible = false;
                Canvas c = new Canvas();
                if (c.ShowDialog() == DialogResult.OK)
                {
                    if (!folder_created) FTPHandle.CreateDir("ScreenShot/" + DateTime.Now.ToShortTimeString(), true);
                    folder_created = true;
                    FTPHandle.FTPSend(c.image);
                }
                this.Visible = true;
                button1.Enabled = true;

            }
            catch (Exception ex)
            {
                ResultsList.FromException(ex);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Tree actions = new Tree();
            actions.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            List<string> titles = new List<string>();
            List<string> snippets = new List<string>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                titles.Add("Test Error Message " + rnd.Next());
            }
            for (int i = 0; i < 10; i++)
            {
                snippets.Add("Test Error Message " + rnd.Next());
            }

            ResultsList rl = new ResultsList(titles, snippets);
            ResultsList.TOConsole(rl);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (!folder_created) FTPHandle.CreateDir("ScreenShot/" + DateTime.Now.ToShortTimeString(), true);
            folder_created = true;
            try
            {
                button1.Enabled = false;
                this.Visible = false;
                Canvas c = new Canvas();
                if (c.ShowDialog() == DialogResult.OK)
                    FTPHandle.FTPSend(c.image);
                this.Visible = true;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                ResultsList.FromException(ex);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            
            if (newconsole)
            {
                this.Close();
            }
            else
            {
                DevConsole.ShowConsole();
            }
            }
    }
}
