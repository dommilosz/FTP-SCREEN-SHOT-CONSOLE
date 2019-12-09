using ControlManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueScreen_Simulator
{
    public partial class BSOD_EDIT : Form
    {
        string prevtxt_1 = "";
        string prevtxt_2 = "";
        string prevtxt_3 = "";
        string prevtxt_4 = "";
        string prevtxt_5 = "";
        string prevtxt_6 = "";
        string savepatch = "not saved";
        int cmin = 1;
        int cmax = 8;
        int tmin = 1000;
        int tmax = 3500;
        bool unsafemode = true;
        string[] dane = new string[100];
        readonly string[] args = new string[100];
        string cmd = "";
        bool closeaftercmd = false;
        bool preview = false;
        Size thissize;
        SizeF scalefactor;
        public BSOD_EDIT()
        {
            InitializeComponent();
            thissize = this.Size;
            ToLog("----NEW-RUN----");
            ThisScale();
            args = Environment.GetCommandLineArgs();
            ToLog(string.Join(" ", args));
            try
            {
                List<string> txt = File.ReadAllLines(Application.ExecutablePath).ToList();
                if (txt.Contains("======[SAVE]======")) { LoadFile(Application.ExecutablePath); BSOD_Start(); }
            }
            catch { }
            CursorShown = true;
            try
            {
                if (args.Length > 1)
                {
                    if (args[1] == "loadfile")
                    {
                        try
                        {
                            string[] tmpvar = args;
                            tmpvar[0] = null;
                            tmpvar[1] = null;
                            ToLog(string.Join(" ", tmpvar).TrimStart(' '));
                            LoadFile(string.Join(" ", tmpvar));

                            BSOD_Start();
                        }
                        catch (Exception ex) { this.Close(); ToLog(ex.ToString()); }
                    }
                }
            }
            catch (Exception ex) { ToLog(ex.ToString()); }
        }

        private bool _CursorShown = true;
        public bool CursorShown
        {
            get
            {
                return _CursorShown;
            }
            set
            {
                if (value == _CursorShown)
                {
                    return;
                }

                if (value)
                {
                    System.Windows.Forms.Cursor.Show();
                }
                else
                {
                    System.Windows.Forms.Cursor.Hide();
                }

                _CursorShown = value;
            }
        }
        public void RunCmd(string command)
        {
            Process Process1 = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", $"/c {cmd.Replace("\n", "&")}");
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process1.StartInfo = startInfo;
            try { Process1.Start(); } catch { }
        }

        private void ToLog(string log)
        {

        }

        int pr = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            pr += rnd.Next(cmin, cmax);
            if (pr >= 100) { pr = 100; RunCmd(cmd); Perc_Timer.Stop(); if (closeaftercmd) { password_in.Text = textBox7.Text; this.Close(); } }
            Perc_Timer.Interval = rnd.Next(tmin, tmax);

        }

        private void BSOD_Start(object sender, EventArgs e)
        {
            BSOD_Start();
        }
        public void BSOD_Start()
        {
            prevtxt_1 = txt_1.Text;
            prevtxt_2 = txt_2.Text;
            prevtxt_3 = txt_3.Text;
            prevtxt_4 = txt_4.Text;
            prevtxt_5 = txt_5.Text;
            prevtxt_6 = txt_6.Text;

            ToLog("BSOD START");
            txt_2.ReadOnly = true;
            button1.Visible = false;
            button2.Visible = false;
            Perc_Timer.Start();
            BSOD_Timer.Start();
            txt_1.ReadOnly = true;
            txt_2.ReadOnly = true;
            txt_3.ReadOnly = true;
            txt_4.ReadOnly = true;
            txt_5.ReadOnly = true;
            txt_6.ReadOnly = true;
            label2.Visible = false;
            textBox7.Visible = false;



            FormatTexts();
            //ThisScale();
        }
        private void ThisScale()
        {
            this.WindowState = FormWindowState.Maximized;
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            float tmp = bounds.Width;
            float tmp2 = bounds.Height;
            float tmp3 = thissize.Width;
            float tmp4 = thissize.Height;
            tmp = tmp / tmp3;
            tmp2 = tmp2 / tmp4;
            SizeF sizeF = new SizeF(tmp, tmp2);
            scalefactor = sizeF;

            txt_1.Scale(sizeF);
            txt_2.Scale(sizeF);
            txt_3.Scale(sizeF);
            txt_4.Scale(sizeF);
            txt_5.Scale(sizeF);
            txt_6.Scale(sizeF);
            textBox7.Scale(sizeF);

            label2.Scale(sizeF);

            button1.Scale(sizeF);
            button2.Scale(sizeF);

            pictureBox1.Scale(sizeF);
            ToLog("Scaling factor " + tmp + " " + tmp2 + " (" + Screen.GetBounds(Point.Empty).Size + "/" + thissize);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (password_in.Text.Contains(textBox7.Text))
            {

                button1.Visible = true;
                button2.Visible = true;
                Perc_Timer.Stop();
                BSOD_Timer.Stop();
                txt_1.ReadOnly = false;
                txt_2.ReadOnly = false;
                txt_3.ReadOnly = false;
                txt_4.ReadOnly = false;
                txt_5.ReadOnly = false;
                txt_6.ReadOnly = false;
                label2.Visible = true;
                textBox7.Visible = true;

                txt_1.Text = prevtxt_1;
                txt_2.Text = prevtxt_2;
                txt_3.Text = prevtxt_3;
                txt_4.Text = prevtxt_4;
                txt_5.Text = prevtxt_5;
                txt_6.Text = prevtxt_6;

                txt_1.SelectAll(); txt_1.SelectionColor = Color.WhiteSmoke;
                txt_2.SelectAll(); txt_2.SelectionColor = Color.WhiteSmoke;
                txt_3.SelectAll(); txt_3.SelectionColor = Color.WhiteSmoke;
                txt_4.SelectAll(); txt_4.SelectionColor = Color.WhiteSmoke;
                txt_5.SelectAll(); txt_5.SelectionColor = Color.WhiteSmoke;
                txt_6.SelectAll(); txt_6.SelectionColor = Color.WhiteSmoke;


                pr = 0;
                CursorShown = true;
                this.TopMost = false;
                this.Select();
                password_in.Text = "";
            }
            else
            {
                password_in.Select();
                CursorShown = false;
                this.TopMost = true;
                FormatTexts();
            }
        }

        public void FormatTexts()
        {
            void FormatVarAll(string var, object value)
            {
                txt_1.FormatVar(var, value);
                txt_2.FormatVar(var, value);
                txt_3.FormatVar(var, value);
                txt_4.FormatVar(var, value);
                txt_5.FormatVar(var, value);
                txt_6.FormatVar(var, value);
            }
            txt_1.Text = prevtxt_1;
            txt_2.Text = prevtxt_2;
            txt_3.Text = prevtxt_3;
            txt_4.Text = prevtxt_4;
            txt_5.Text = prevtxt_5;
            txt_6.Text = prevtxt_6;

            FormatVarAll("p", pr);
            FormatVarAll("pass", textBox7.Text);
            FormatVarAll("cmd", cmd);
            FormatVarAll("scale-x", scalefactor.Width);
            FormatVarAll("scale-y", scalefactor.Height);
            FormatVarAll("width", Bounds.Width);
            FormatVarAll("height", Bounds.Height);
            FormatVarAll("tmin", tmin);
            FormatVarAll("tmax", tmax);
            FormatVarAll("cmin", cmin);
            FormatVarAll("cmax", cmax);
            FormatVarAll("unsmode", unsafemode);
            FormatVarAll("closecmd", closeaftercmd);

            txt_1.FormatTxt();
            txt_2.FormatTxt();
            txt_3.FormatTxt();
            txt_4.FormatTxt();
            txt_5.FormatTxt();
            txt_6.FormatTxt();

        }

        private void SaveFile(string patch)
        {
            try
            {
                dane[0] = txt_1.Text.Replace("\n", "{endl}");
                dane[1] = txt_2.Text.Replace("\n", "{endl}");
                dane[2] = txt_3.Text.Replace("\n", "{endl}");
                dane[3] = txt_4.Text.Replace("\n", "{endl}");
                dane[4] = txt_5.Text.Replace("\n", "{endl}");
                dane[5] = txt_6.Text.Replace("\n", "{endl}");
                dane[6] = "//timer settings";
                dane[7] = cmin.ToString();
                dane[8] = cmax.ToString();
                dane[9] = tmin.ToString();
                dane[10] = tmax.ToString();
                dane[11] = "//color settings";
                dane[12] = this.BackColor.R.ToString();
                dane[13] = this.BackColor.G.ToString();
                dane[14] = this.BackColor.B.ToString();
                string locdata = "";
                locdata += $"|{txt_1.Location.X}*{txt_1.Location.Y}#{txt_1.Size.Width}*{txt_1.Size.Height}|";
                locdata += $"|{txt_2.Location.X}*{txt_2.Location.Y}#{txt_2.Size.Width}*{txt_2.Size.Height}|";
                locdata += $"|{txt_3.Location.X}*{txt_3.Location.Y}#{txt_3.Size.Width}*{txt_3.Size.Height}|";
                locdata += $"|{txt_4.Location.X}*{txt_4.Location.Y}#{txt_4.Size.Width}*{txt_4.Size.Height}|";
                locdata += $"|{txt_5.Location.X}*{txt_5.Location.Y}#{txt_5.Size.Width}*{txt_5.Size.Height}|";
                locdata += $"|{txt_6.Location.X}*{txt_6.Location.Y}#{txt_6.Size.Width}*{txt_6.Size.Height}|";
                dane[15] = locdata;
                Font font;
                Font font2;
                Font font3;
                var fcv = new FontConverter();
                font = txt_2.Font;
                font2 = txt_1.Font;
                font3 = txt_4.Font;

                dane[18] = "//password settings";
                dane[19] = textBox7.Text;
                dane[20] = "//image settings";
                dane[21] = "default";
                dane[22] = unsafemode.ToString();
                //dane[23] = txt_2.Font.Size.ToString();
                //dane[24] = txt_4.Font.Size.ToString();
                //dane[25] = txt_1.Font.Size.ToString();

                dane[23] = fcv.ConvertToString(font);
                dane[24] = fcv.ConvertToString(font2);
                dane[25] = fcv.ConvertToString(font2);

                dane[28] = cmd.Replace("\n", "{endl}");
                dane[29] = closeaftercmd.ToString();

                saveFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
                var dialog = DialogResult.None;

                if (patch == "dialog")
                {
                    dialog = saveFileDialog1.ShowDialog();
                }
                else
                {
                    saveFileDialog1.FileName = patch;
                    dialog = DialogResult.OK;
                }

                if (dialog == DialogResult.OK)
                {
                    Random rnd = new Random();
                    var tmp = saveFileDialog1.FileName;
                    if (pictureBox1.Image != pictureBox2.Image)
                    {
                        string[] tmp2 = tmp.Split('.');
                        //pictureBox1.Image.Save(tmp2[0]+".QR");

                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, ImageFormat.Png);
                        byte[] bytes = ms.ToArray();
                        string byteString = Convert.ToBase64String(bytes);
                        dane[21] = byteString;
                    }
                    CloneExeWithSave(saveFileDialog1.FileName, dane);
                    //File.WriteAllLines(saveFileDialog1.FileName, dane);

                    savepatch = saveFileDialog1.FileName;
                }
                saveFileDialog1.FileName = "";
                openFileDialog1.FileName = "";
                ToLog("Saved dir " + savepatch);
            }
            catch (Exception ex) { ToLog(ex.ToString()); }
        }

        private void LoadFile(string patch)
        {

            openFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
            var dialog = DialogResult.None;

            if (patch == "dialog")
            {
                dialog = openFileDialog1.ShowDialog();
            }
            else
            {
                openFileDialog1.FileName = patch;
                dialog = DialogResult.OK;
            }

            openFileDialog1.Filter = "Binary (.exe)|*.exe";
            openFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
            if (dialog == DialogResult.OK)
            {
                try
                {
                    if (patch.Contains("{resource/txt/prop}"))
                    {
                        string txt = "";
                        if (patch.Contains("varsdemo.txt"))
                            txt = Properties.Resources.varsdemo;
                        if (patch.Contains("default.txt"))
                            txt = Properties.Resources._default;
                        if (patch.Contains("win7.txt"))
                            txt = Properties.Resources.win7;
                        txt = txt.Replace("\r", "");
                        dane = txt.Split('\n');
                    }
                    else { dane = ReadExeWithSave(openFileDialog1.FileName); }
                    txt_1.Text = dane[0].Replace("{endl}", "\n");
                    txt_2.Text = dane[1].Replace("{endl}", "\n");
                    txt_3.Text = dane[2].Replace("{endl}", "\n");
                    txt_4.Text = dane[3].Replace("{endl}", "\n");
                    txt_5.Text = dane[4].Replace("{endl}", "\n");
                    txt_6.Text = dane[5].Replace("{endl}", "\n");
                    dane[6] = "//timer settings";
                    cmin = Convert.ToInt32(dane[7]);
                    cmax = Convert.ToInt32(dane[8]);
                    tmin = Convert.ToInt32(dane[9]);
                    tmax = Convert.ToInt32(dane[10]);
                    dane[11] = "//color settings";
                    colorDialog1.Color = Color.FromArgb(Convert.ToInt32(dane[12]), Convert.ToInt32(dane[13]), Convert.ToInt32(dane[14]));
                    this.BackColor = colorDialog1.Color;
                    txt_1.BackColor = colorDialog1.Color;
                    txt_2.BackColor = colorDialog1.Color;
                    txt_3.BackColor = colorDialog1.Color;
                    txt_4.BackColor = colorDialog1.Color;
                    txt_5.BackColor = colorDialog1.Color;
                    txt_6.BackColor = colorDialog1.Color;
                    button1.BackColor = colorDialog1.Color;
                    button2.BackColor = colorDialog1.Color;
                    textBox7.Text = dane[19];
                    string locdata = dane[15];
                    List<string> locdatas = locdata.Split('|').ToList();
                    while (locdatas.Contains(""))
                    {
                        locdatas.Remove("");
                    }
                    for (int i = 0; i < locdatas.Count; i++)
                    {
                        List<string> locdat = locdatas[i].Split('#').ToList();
                        List<string> loc = locdat[0].Split('*').ToList();
                        List<string> size = locdat[1].Split('*').ToList();
                        Point Location = new Point(Convert.ToInt32(loc[0]), Convert.ToInt32(loc[1]));
                        Size Size = new Size(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
                        if (i == 0) { txt_1.Location = Location; txt_1.Size = Size; }
                        if (i == 1) { txt_2.Location = Location; txt_2.Size = Size; }
                        if (i == 2) { txt_3.Location = Location; txt_3.Size = Size; }
                        if (i == 3) { txt_4.Location = Location; txt_4.Size = Size; }
                        if (i == 4) { txt_5.Location = Location; txt_5.Size = Size; }
                        if (i == 5) { txt_6.Location = Location; txt_6.Size = Size; }
                    }

                    if (dane[21].Replace("\r", "") != "default")
                    {
                        var bytes = Convert.FromBase64String(dane[21]);
                        var stream = new MemoryStream(bytes);
                        pictureBox1.Image = Image.FromStream(stream);
                    }

                    unsafemode = Convert.ToBoolean(dane[22]);
                    savepatch = openFileDialog1.FileName;

                    FormatFont(dane[23], dane[24], dane[25]);

                    saveFileDialog1.FileName = "";
                    openFileDialog1.FileName = "";
                    cmd = dane[28].Replace("{endl}", "\r\n");
                    closeaftercmd = Convert.ToBoolean(dane[29]);
                }
                catch (Exception ex) { ToLog(ex.ToString()); }
            }
            saveFileDialog1.FileName = "";
            openFileDialog1.FileName = "";
        }
        private void CloneExeWithSave(string patch, string[] dane)
        {
            if (File.Exists(patch))
                File.Delete(patch);
            List<string> data = new List<string>();
            File.Copy(Application.ExecutablePath, patch);
            data.Add("\n");
            data.Add("\n");
            data.Add(@"======[BSOD=AUTORUN]======");
            data.Add(@"======[SAVE]======");
            data.AddRange(dane);
            File.AppendAllLines(patch, data.ToArray());
        }
        private string[] ReadExeWithSave(string patch)
        {
            List<string> data = new List<string>();
            data = File.ReadAllLines(patch).ToList();
            List<string> newdata = new List<string>();
            newdata.AddRange(data);
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] != @"======[SAVE]======")
                {
                    newdata.RemoveAt(0);
                }
                else { newdata.RemoveAt(0); break; }
            }
            return newdata.ToArray();
        }

        private void FormatFont(string FM, string FQ, string FE)
        {
            FontConverter fcv = new FontConverter();
            Font mfs;
            Font qfs;
            Font efs;
            if (FQ == "" && FM == "" && FE == "")
            {
                FM = "Microsoft JhengHei UI Light; 18pt";
                FQ = "Microsoft JhengHei UI Light; 9,25pt";
                FE = "Microsoft YaHei UI; 100pt";
            }
            mfs = (fcv.ConvertFromString(FM) as Font);
            qfs = (fcv.ConvertFromString(FQ) as Font);
            efs = (fcv.ConvertFromString(FE) as Font);

            Font font_Main = mfs;
            Font font_QR = qfs;
            Font font_Emo = efs;

            txt_1.Font = font_Emo;

            txt_2.Font = font_Main;
            txt_3.Font = font_Main;

            txt_4.Font = font_QR;
            txt_5.Font = font_QR;
            txt_6.Font = font_QR;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.FromArgb(0, 120, 215);
            this.BackColor = colorDialog1.Color;
            txt_1.BackColor = colorDialog1.Color;
            txt_2.BackColor = colorDialog1.Color;
            txt_3.BackColor = colorDialog1.Color;
            txt_4.BackColor = colorDialog1.Color;
            txt_5.BackColor = colorDialog1.Color;
            txt_6.BackColor = colorDialog1.Color;
        }

        private void BSOD_EDIT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (password_in.Text != textBox7.Text && BSOD_Timer.Enabled && unsafemode) e.Cancel = true;
            if (preview) e.Cancel = true;
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile("dialog");
        }

        private void lOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile("dialog");
        }

        private void cHANGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                txt_1.BackColor = colorDialog1.Color;
                txt_2.BackColor = colorDialog1.Color;
                txt_3.BackColor = colorDialog1.Color;
                txt_4.BackColor = colorDialog1.Color;
                txt_5.BackColor = colorDialog1.Color;
                txt_6.BackColor = colorDialog1.Color;
                button1.BackColor = colorDialog1.Color;
                button2.BackColor = colorDialog1.Color;
            }
        }

        private void rESETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.FromArgb(0, 120, 215);
            this.BackColor = colorDialog1.Color;
            txt_1.BackColor = colorDialog1.Color;
            txt_2.BackColor = colorDialog1.Color;
            txt_3.BackColor = colorDialog1.Color;
            txt_4.BackColor = colorDialog1.Color;
            txt_5.BackColor = colorDialog1.Color;
            txt_6.BackColor = colorDialog1.Color;
            button1.BackColor = colorDialog1.Color;
            button2.BackColor = colorDialog1.Color;
        }

        private void cHANGEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try { pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); } catch (Exception ex) { ToLog(ex.ToString()); }
            }
            saveFileDialog1.FileName = "";
            openFileDialog1.FileName = "";
        }

        private void rESETToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
        }

        private void sETTINGSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(unsafemode, !pictureBox1.Visible, savepatch, txt_2.Font, txt_4.Font, txt_1.Font, cmd, closeaftercmd, cmin, cmax, tmin, tmax);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                unsafemode = settings.unsmode.Checked;
                string MF = settings.txt_Font_f1.Text;
                string QF = settings.txt_Font_f2.Text;
                string EF = settings.txt_Font_f3.Text;
                FormatFont(MF, QF, EF);
                cmd = settings.textBox1.Text;
                closeaftercmd = settings.checkBox1.Checked;
                try
                {
                    cmin = Convert.ToInt32(settings.cmin.Value);
                    tmin = Convert.ToInt32(settings.tmin.Value);
                    cmax = Convert.ToInt32(settings.cmax.Value);
                    tmax = Convert.ToInt32(settings.tmax.Value);
                }
                catch (Exception ex) { ToLog(ex.ToString()); }
            }
        }
        Control _sc = null;
        private void cHANGEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                /*this.ForeColor = colorDialog1.Color;
                textBox1.ForeColor = colorDialog1.Color;
                textBox2.ForeColor = colorDialog1.Color;
                textBox3.ForeColor = colorDialog1.Color;
                textBox4.ForeColor = colorDialog1.Color;
                textBox5.ForeColor = colorDialog1.Color;
                textBox6.ForeColor = colorDialog1.Color;
                textBox8.ForeColor = colorDialog1.Color;
                textBox9.ForeColor = colorDialog1.Color;*/

                _sc.ForeColor = colorDialog1.Color;
            }
        }

        private void rESETToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.White;
            /*this.ForeColor = colorDialog1.Color;
            textBox1.ForeColor = colorDialog1.Color;
            textBox2.ForeColor = colorDialog1.Color;
            textBox3.ForeColor = colorDialog1.Color;
            textBox4.ForeColor = colorDialog1.Color;
            textBox5.ForeColor = colorDialog1.Color;
            textBox6.ForeColor = colorDialog1.Color;
            textBox8.ForeColor = colorDialog1.Color;
            textBox9.ForeColor = colorDialog1.Color;
            label1.ForeColor = colorDialog1.Color;*/
            _sc.ForeColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            preview = !preview;
            txt_1.ReadOnly = preview;
            txt_2.ReadOnly = preview;
            txt_3.ReadOnly = preview;
            txt_4.ReadOnly = preview;
            txt_5.ReadOnly = preview;
            txt_6.ReadOnly = preview;
            button1.Enabled = !preview;
            textBox7.Enabled = !preview;
            if (preview)
            {
                prevtxt_1 = txt_1.Text;
                prevtxt_2 = txt_2.Text;
                prevtxt_3 = txt_3.Text;
                prevtxt_4 = txt_4.Text;
                prevtxt_5 = txt_5.Text;
                prevtxt_6 = txt_6.Text;
                button2.BackColor = Color.Green;
                FormatTexts();
            }
            else
            {
                button2.BackColor = this.BackColor;
                txt_1.Text = prevtxt_1;
                txt_2.Text = prevtxt_2;
                txt_3.Text = prevtxt_3;
                txt_4.Text = prevtxt_4;
                txt_5.Text = prevtxt_5;
                txt_6.Text = prevtxt_6;

                txt_1.SelectAll(); txt_1.SelectionColor = Color.WhiteSmoke;
                txt_2.SelectAll(); txt_2.SelectionColor = Color.WhiteSmoke;
                txt_3.SelectAll(); txt_3.SelectionColor = Color.WhiteSmoke;
                txt_4.SelectAll(); txt_4.SelectionColor = Color.WhiteSmoke;
                txt_5.SelectAll(); txt_5.SelectionColor = Color.WhiteSmoke;
                txt_6.SelectAll(); txt_6.SelectionColor = Color.WhiteSmoke;
            }
        }

        private void rESETToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            LoadFile("default.txt{resource/txt/prop}");
        }

        private void lOADDEMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile("varsdemo.txt{resource/txt/prop}");
        }

        public bool editing = false;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editing = !editing;
            toolStripMenuItem1.Checked = editing;
            if (editing)
            {
                ControlMoverOrResizer.Init(txt_1);
                ControlMoverOrResizer.Init(txt_2);
                ControlMoverOrResizer.Init(txt_3);
                ControlMoverOrResizer.Init(txt_4);
                ControlMoverOrResizer.Init(txt_5);
                ControlMoverOrResizer.Init(txt_6);
                ControlMoverOrResizer.Init(pictureBox1);
            }
            if (!editing)
            {
                ControlMoverOrResizer.Unload(txt_1);
                ControlMoverOrResizer.Unload(txt_2);
                ControlMoverOrResizer.Unload(txt_3);
                ControlMoverOrResizer.Unload(txt_4);
                ControlMoverOrResizer.Unload(txt_5);
                ControlMoverOrResizer.Unload(txt_6);
                ControlMoverOrResizer.Unload(pictureBox1);
                txt_1.Cursor = Cursors.IBeam;
                txt_2.Cursor = Cursors.IBeam;
                txt_3.Cursor = Cursors.IBeam;
                txt_4.Cursor = Cursors.IBeam;
                txt_5.Cursor = Cursors.IBeam;
                txt_6.Cursor = Cursors.IBeam;
                this.CreateGraphics().Clear(this.BackColor);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (BSOD_Timer.Enabled || preview) e.Cancel = true;
        }
        Control _sourceControl = null;
        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            _sourceControl = contextMenuStrip1.SourceControl;
            //if (_sourceControl.Name.Contains("txt_") || _sourceControl.Name.Contains("pictureBox1"))
            //{
            //    contextMenuStrip1.Items[1].Visible = true;
            //}
            //else contextMenuStrip1.Items[1].Visible =false;
        }

        private void win7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile("win7.txt{resource/txt/prop}");
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public static void FormatTxt(this RichTextBox r)
        {
            r.SelectAll();
            r.SelectionColor = Color.WhiteSmoke;
            Color DecodeCode(char code)
            {
                Color color = Color.White;
                switch (code)
                {
                    case '0': color = Color.Black; break;
                    case '1': color = Color.DarkBlue; break;
                    case '2': color = Color.DarkGreen; break;
                    case '3': color = Color.DarkCyan; break;
                    case '4': color = Color.DarkRed; break;
                    case '5': color = Color.DarkMagenta; break;
                    case '6': color = Color.Gold; break;
                    case '7': color = Color.Gray; break;
                    case '8': color = Color.DarkGray; break;
                    case '9': color = Color.Blue; break;

                    case 'a': color = Color.Green; break;
                    case 'b': color = Color.Cyan; break;
                    case 'c': color = Color.Red; break;
                    case 'd': color = Color.Magenta; break;
                    case 'e': color = Color.Yellow; break;
                    case 'f': color = Color.White; break;
                }
                return color;
            }
            void WriteTxt(string txt)
            {
                txt += "    ";
                Color c = DecodeCode('f');
                string codes = "0123456789abcdef";
                for (int i = 0; i < txt.Length; i++)
                {
                    if (i >= 0 && txt[i] == '@' && txt[i + 1] == '&' && codes.Contains(txt[i + 2]))
                    {
                        c = DecodeCode(txt[i + 2]);
                        txt = txt.Remove(i + 2, 1);
                        txt = txt.Remove(i + 1, 1);
                        txt = txt.Remove(i, 1);
                    }
                    if (txt.Length - 1 > i + 1 && txt[i] == '&' && codes.Contains(txt[i + 1]))
                    {
                        if (i - 1 >= 0 && txt[i - 1] == @"\"[0])
                        {
                            if (i < txt.Length - 4)
                            {
                                AppChar(txt[i], c);
                            }
                        }
                        else { c = DecodeCode(txt[i + 1]); txt = txt.Remove(i + 1, 1); }
                    }
                    else { bool tmp = (i < txt.Length - 4); if (txt[i] == '@' && txt[i + 1] == '&') tmp = false; if (txt[i] == '&' && codes.Contains(txt[i + 1])) tmp = false; if (txt[i] == @"\"[0] && txt[i + 1] == '&' && codes.Contains(txt[i + 2])) tmp = false; if (tmp) { AppChar(txt[i], c); } }

                }
                c = Color.White;
            }
            void AppChar(char c, Color c2)
            {
                //int selectStart = r.SelectionStart;
                //r.Text += (c);
                //r.SelectionColor = c2;
                //r.Select(r.Text.Length - 1, 1); 
                //r.SelectionColor = c2;
                //r.Select(selectStart, 0);
                //r.SelectionColor = ForeColor;
                r.AppendText(c.ToString(), c2);
            }
            string tmptxt = r.Text;
            r.Text = "";
            WriteTxt(tmptxt);

        }
        public static void FormatTxtNORemoveCodes(this RichTextBox r)
        {
            r.SelectAll();
            r.SelectionColor = Color.WhiteSmoke;
            Color DecodeCode(char code)
            {
                Color color = Color.White;
                switch (code)
                {
                    case '0': color = Color.Black; break;
                    case '1': color = Color.DarkBlue; break;
                    case '2': color = Color.DarkGreen; break;
                    case '3': color = Color.DarkCyan; break;
                    case '4': color = Color.DarkRed; break;
                    case '5': color = Color.DarkMagenta; break;
                    case '6': color = Color.Gold; break;
                    case '7': color = Color.Gray; break;
                    case '8': color = Color.DarkGray; break;
                    case '9': color = Color.Blue; break;

                    case 'a': color = Color.Green; break;
                    case 'b': color = Color.Cyan; break;
                    case 'c': color = Color.Red; break;
                    case 'd': color = Color.Magenta; break;
                    case 'e': color = Color.Yellow; break;
                    case 'f': color = Color.White; break;
                }
                return color;
            }
            void WriteTxt(string txt)
            {
                txt += "    ";
                Color c = DecodeCode('f');
                string codes = "0123456789abcdef";
                for (int i = 0; i < txt.Length; i++)
                {
                    if (i >= 0 && txt[i] == '@' && txt[i + 1] == '&' && codes.Contains(txt[i + 2]))
                    {
                        c = DecodeCode(txt[i + 2]);
                    }
                    if (txt.Length - 1 > i + 1 && txt[i] == '&' && codes.Contains(txt[i + 1]))
                    {
                        if (i - 1 >= 0 && txt[i - 1] == @"\"[0])
                        {
                            if (i < txt.Length - 4)
                            {
                                AppChar(txt[i], c);
                            }
                        }
                        else { c = DecodeCode(txt[i + 1]); txt = txt.Remove(i + 1, 1); }
                    }
                    else { bool tmp = (i < txt.Length - 4); if (tmp) { AppChar(txt[i], c); } }

                }
                c = Color.White;
            }
            void AppChar(char c, Color c2)
            {
                //int selectStart = r.SelectionStart;
                //r.Text += (c);
                //r.SelectionColor = c2;
                //r.Select(r.Text.Length - 1, 1); 
                //r.SelectionColor = c2;
                //r.Select(selectStart, 0);
                //r.SelectionColor = ForeColor;
                r.AppendText(c.ToString(), c2);
            }
            string tmptxt = r.Text;
            r.Text = "";
            WriteTxt(tmptxt);

        }
        public static void FormatVar(this RichTextBox r, string var, object value)
        {
            string vl = value.ToString();
            var = "{" + var + "}";
            string txt = r.Text.Replace(var, vl);
            r.Text = txt;
        }
    }
}
