﻿using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using File = System.IO.File;

namespace BlueScreen_Simulator
{
    public partial class Settings : Form
    {
        string savepatch;
        //public DialogResult DialogResult = DialogResult.None;
        public Settings()
        {
            InitializeComponent();

        }
        public Settings(bool us, bool hpr, string savepatch2, Font MF, Font QF, Font EF, string cmd, bool cac, int cmin2, int cmax2, int tmin2, int tmax2)
        {
            InitializeComponent();
            unsmode.Checked = us;
            savepatch = savepatch2;
            FontConverter fcv = new FontConverter();
            txt_Font_f1.Text = fcv.ConvertToString(MF);
            txt_Font_f2.Text = fcv.ConvertToString(QF);
            txt_Font_f3.Text = fcv.ConvertToString(EF);
            textBox1.Text = cmd;
            checkBox1.Checked = cac;
            cmin.Value = cmin2;
            tmin.Value = tmin2;
            cmax.Value = cmax2;
            tmax.Value = tmax2;
            this.Opacity = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (savepatch != "not saved")
            {
                saveFileDialog1.Filter = "Shortcut (.lnk)|*.lnk|Bat file (.bat)|*.bat";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName.Contains(".bat"))
                    {
                        string[] tmp = new string[100];
                        char tmp2 = '"';
                        tmp[0] = "cd " + Application.StartupPath;
                        tmp[1] = tmp2 + "BlueScreen Simulator" + tmp2 + " loadfile " + savepatch;
                        File.WriteAllLines(saveFileDialog1.FileName, tmp);
                    }
                    else
                    {
                        string[] tmp = new string[100];
                        char tmp2 = '"';
                        tmp[0] = "cd " + Application.StartupPath;
                        tmp[1] = tmp2 + "BlueScreen Simulator" + tmp2 + " loadfile " + savepatch;
                        if (saveFileDialog1.FileName.Contains(".lnk")) { } else { saveFileDialog1.FileName += ".lnk"; }

                        object shDesktop = (object)"Desktop";
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(saveFileDialog1.FileName);
                        shortcut.TargetPath = Application.ExecutablePath;
                        shortcut.Arguments = " loadfile " + savepatch;
                        shortcut.Save();

                        saveFileDialog1.FileName = "";
                        openFileDialog1.FileName = "";
                    }
                }
            }
            else { MessageBox.Show("Load or Save first"); }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) { this.Opacity += 0.02; }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            timer2.Start();

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0) { this.Opacity -= 0.05; }
            if (this.Opacity <= 0) this.Close();

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Process Process1 = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {textBox1.Text.Replace("\n", "&")}");
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process1.StartInfo = startInfo;
            try { Process1.Start(); } catch { }
        }

        private void btn_Font_Change_f3_Click(object sender, EventArgs e)
        {
            FontConverter fcv = new FontConverter();
            Button s = sender as Button;
            if (s.Name.Contains("f1")) { fontDialog1.Font = fcv.ConvertFromString(txt_Font_f1.Text) as Font; }
            if (s.Name.Contains("f2")) { fontDialog1.Font = fcv.ConvertFromString(txt_Font_f2.Text) as Font; }
            if (s.Name.Contains("f3")) { fontDialog1.Font = fcv.ConvertFromString(txt_Font_f3.Text) as Font; }
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font f;
                f = fontDialog1.Font;

                if (s.Name.Contains("f1"))
                {
                    txt_Font_f1.Text = fcv.ConvertToString(f);
                }
                if (s.Name.Contains("f2"))
                {
                    txt_Font_f2.Text = fcv.ConvertToString(f);
                }
                if (s.Name.Contains("f3"))
                {
                    txt_Font_f3.Text = fcv.ConvertToString(f);
                }
            }
        }
    }
}
