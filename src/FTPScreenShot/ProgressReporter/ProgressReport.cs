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
    public partial class ProgressReport : Form
    {
        static ProgressBarDialog pbd;
        public ProgressReport(float v, float max)
        {
            InitializeComponent();
            float w = v / max;
            string pers = (w * 100).ToString().Split(',')[0];
            int per = Convert.ToInt32(pers);
            pbd.progressBar1.Value = per;
            pbd.Text = "Downloading...    [" + per + "%]";
            DevConsole.ShowGetConsole().SendCmd("echocl violet " + pbd.Text);
        }
        public static void Report(float v, float max)
        {
            ProgressReport pd = new ProgressReport(v, max);
            pd.ShowDialog();

        }
        public static void StartReporting()
        {
            ProgressBarDialog p = new ProgressBarDialog();
            p.Show();
            pbd = p;

        }
        public static void StopReporting()
        {
            pbd.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
