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
        string prevtxt_7 = "";
        string prevtxt_8 = "";
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
        Size thissize;
        public BSOD_EDIT()
        {
            InitializeComponent();

            thissize = this.Size;
            ToLog("----NEW-RUN----");
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            ThisScale();
            args = Environment.GetCommandLineArgs();
            ToLog(string.Join(" ", args));
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

                            pictureBox3.Dock = DockStyle.Fill;
                            timer3.Start();
                            pictureBox3.BackColor = this.BackColor;
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
            ProcessStartInfo startInfo = new ProcessStartInfo(cmd);
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
            if (pr >= 100) { pr = 100; RunCmd(cmd); Perc_Timer.Stop(); if (closeaftercmd) password_in.Text = textBox7.Text; }
            Perc_Timer.Interval = rnd.Next(tmin, tmax);

        }

        private void BSOD_Start(object sender, EventArgs e)
        {
            BSOD_Start();
        }
        public void BSOD_Start()
        {
            ToLog("BSOD START");
            txt_2.ReadOnly = true;
            button1.Visible = false;
            Perc_Timer.Start();
            BSOD_Timer.Start();
            txt_5.ReadOnly = true;
            txt_6.ReadOnly = true;
            txt_7.ReadOnly = true;
            txt_8.ReadOnly = true;
            txt_1.ReadOnly = true;
            label2.Visible = false;
            textBox7.Visible = false;
            txt_5.Visible = true;
            txt_3.ReadOnly = true;
            txt_4.ReadOnly = true;
            prevtxt_1 = txt_1.Text;
            prevtxt_2 = txt_2.Text;
            prevtxt_3 = txt_3.Text;
            prevtxt_4 = txt_4.Text;
            prevtxt_5 = txt_5.Text;
            prevtxt_6 = txt_6.Text;
            prevtxt_7 = txt_7.Text;
            prevtxt_8 = txt_8.Text;

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

            txt_2.Scale(sizeF);
            txt_5.Scale(sizeF);
            txt_6.Scale(sizeF);
            txt_7.Scale(sizeF);
            txt_8.Scale(sizeF);
            txt_1.Scale(sizeF);
            textBox7.Scale(sizeF);
            txt_3.Scale(sizeF);
            txt_4.Scale(sizeF);

            label2.Scale(sizeF);

            button1.Scale(sizeF);

            pictureBox1.Scale(sizeF);
            ToLog("Scaling factor " + tmp + " " + tmp2 + " (" + Screen.GetBounds(Point.Empty).Size + "/" + thissize);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (password_in.Text.Contains(textBox7.Text))
            {
                txt_2.ReadOnly = false;
                button1.Visible = true;
                Perc_Timer.Stop();
                BSOD_Timer.Stop();
                txt_5.ReadOnly = false;
                txt_6.ReadOnly = false;
                txt_7.ReadOnly = false;
                txt_8.ReadOnly = false;
                txt_1.ReadOnly = false;
                label2.Visible = true;
                textBox7.Visible = true;
                txt_3.ReadOnly = false;
                txt_4.ReadOnly = false;

                txt_1.Text = prevtxt_1;
                txt_2.Text = prevtxt_2;
                txt_3.Text = prevtxt_3;
                txt_4.Text = prevtxt_4;
                txt_5.Text = prevtxt_5;
                txt_6.Text = prevtxt_6;
                txt_7.Text = prevtxt_7;
                txt_8.Text = prevtxt_8;

                txt_1.SelectAll(); txt_1.SelectionColor = Color.WhiteSmoke;
                txt_2.SelectAll(); txt_2.SelectionColor = Color.WhiteSmoke;
                txt_3.SelectAll(); txt_3.SelectionColor = Color.WhiteSmoke;
                txt_4.SelectAll(); txt_4.SelectionColor = Color.WhiteSmoke;
                txt_5.SelectAll(); txt_5.SelectionColor = Color.WhiteSmoke;
                txt_6.SelectAll(); txt_6.SelectionColor = Color.WhiteSmoke;
                txt_7.SelectAll(); txt_7.SelectionColor = Color.WhiteSmoke;
                txt_8.SelectAll(); txt_8.SelectionColor = Color.WhiteSmoke;


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
            txt_1.Text = prevtxt_1;
            txt_2.Text = prevtxt_2;
            txt_3.Text = prevtxt_3;
            txt_4.Text = prevtxt_4;
            txt_5.Text = prevtxt_5;
            txt_6.Text = prevtxt_6;
            txt_7.Text = prevtxt_7;
            txt_8.Text = prevtxt_8;

            txt_1.FormatVar("p", pr);
            txt_2.FormatVar("p", pr);
            txt_3.FormatVar("p", pr);
            txt_4.FormatVar("p", pr);
            txt_5.FormatVar("p", pr);
            txt_6.FormatVar("p", pr);
            txt_7.FormatVar("p", pr);
            txt_8.FormatVar("p", pr);

            txt_1.FormatVar("pass", textBox7.Text);
            txt_2.FormatVar("pass", textBox7.Text);
            txt_3.FormatVar("pass", textBox7.Text);
            txt_4.FormatVar("pass", textBox7.Text);
            txt_5.FormatVar("pass", textBox7.Text);
            txt_6.FormatVar("pass", textBox7.Text);
            txt_7.FormatVar("pass", textBox7.Text);
            txt_8.FormatVar("pass", textBox7.Text);

            txt_1.FormatTxt();
            txt_2.FormatTxt();
            txt_3.FormatTxt();
            txt_4.FormatTxt();
            txt_5.FormatTxt();
            txt_6.FormatTxt();
            txt_7.FormatTxt();
            txt_8.FormatTxt();

        }

        private void SaveFile(string patch)
        {
            try
            {
                dane[0] = txt_2.Text;
                dane[1] = txt_5.Text;
                dane[2] = txt_6.Text;
                dane[3] = txt_7.Text;
                dane[4] = txt_8.Text;
                dane[5] = txt_1.Text;
                dane[6] = "//timer settings";
                dane[7] = cmin.ToString();
                dane[8] = cmax.ToString();
                dane[9] = tmin.ToString();
                dane[10] = tmax.ToString();
                dane[11] = "//color settings";
                dane[12] = this.BackColor.R.ToString();
                dane[13] = this.BackColor.G.ToString();
                dane[14] = this.BackColor.B.ToString();
                //dane[15] = this.ForeColor.R.ToString();
                //dane[16] = this.ForeColor.G.ToString();
                //dane[17] = this.ForeColor.B.ToString();
                dane[18] = "//password settings";
                dane[19] = textBox7.Text;
                dane[20] = "//image settings";
                dane[21] = "default";
                dane[22] = unsafemode.ToString();
                dane[23] = txt_2.Font.Size.ToString();
                dane[24] = txt_6.Font.Size.ToString();
                dane[25] = txt_1.Font.Size.ToString();
                dane[26] = txt_3.Text;
                dane[27] = txt_4.Text;
                dane[28] = cmd;
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
                        pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] bytes = ms.ToArray();
                        string byteString = Convert.ToBase64String(bytes);
                        dane[21] = byteString;
                    }
                    File.WriteAllLines(saveFileDialog1.FileName, dane);

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

            openFileDialog1.Filter = "Save Files (.txt)|*.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath + @"\Data";
            if (dialog == DialogResult.OK)
            {
                try
                {
                    dane = File.ReadAllLines(openFileDialog1.FileName);
                    txt_2.Text = dane[0];
                    txt_5.Text = dane[1];
                    txt_6.Text = dane[2];
                    txt_7.Text = dane[3];
                    txt_8.Text = dane[4];
                    txt_1.Text = dane[5];
                    txt_3.Text = dane[26];
                    txt_4.Text = dane[27];
                    dane[6] = "//timer settings";
                    cmin = Convert.ToInt32(dane[7]);
                    cmax = Convert.ToInt32(dane[8]);
                    tmin = Convert.ToInt32(dane[9]);
                    tmax = Convert.ToInt32(dane[10]);
                    dane[11] = "//color settings";
                    colorDialog1.Color = Color.FromArgb(Convert.ToInt32(dane[12]), Convert.ToInt32(dane[13]), Convert.ToInt32(dane[14]));
                    this.BackColor = colorDialog1.Color;
                    txt_2.BackColor = colorDialog1.Color;
                    txt_5.BackColor = colorDialog1.Color;
                    txt_6.BackColor = colorDialog1.Color;
                    txt_7.BackColor = colorDialog1.Color;
                    txt_8.BackColor = colorDialog1.Color;
                    txt_1.BackColor = colorDialog1.Color;
                    txt_3.BackColor = colorDialog1.Color;
                    txt_4.BackColor = colorDialog1.Color;
                    //colorDialog1.Color = Color.White;
                    //colorDialog1.Color = Color.FromArgb(Convert.ToInt32(dane[15]), Convert.ToInt32(dane[16]), Convert.ToInt32(dane[17]));
                    //this.ForeColor = colorDialog1.Color;
                    //txt_2.ForeColor = colorDialog1.Color;
                    //txt_5.ForeColor = colorDialog1.Color;
                    //txt_6.ForeColor = colorDialog1.Color;
                    //txt_7.ForeColor = colorDialog1.Color;
                    //txt_8.ForeColor = colorDialog1.Color;
                    //txt_1.ForeColor = colorDialog1.Color;
                    //txt_3.ForeColor = colorDialog1.Color;
                    //txt_4.ForeColor = colorDialog1.Color;
                    textBox7.Text = dane[19];
                    if (dane[21] != "default")
                    {
                        var bytes = Convert.FromBase64String(dane[21]);
                        var stream = new MemoryStream(bytes);
                        pictureBox1.Image = Image.FromStream(stream);
                    }

                    unsafemode = Convert.ToBoolean(dane[22]);
                    savepatch = openFileDialog1.FileName;

                    float MF = (float)Convert.ToDouble(dane[23]);
                    Font font = new Font("Microsoft JhengHei UI Light", MF);
                    txt_2.Font = font;
                    txt_3.Font = font;
                    txt_4.Font = font;
                    txt_5.Font = font;
                    float QF = (float)Convert.ToDouble(dane[24]);
                    font = new Font("Microsoft JhengHei UI Light", QF);
                    txt_6.Font = font;
                    txt_7.Font = font;
                    txt_8.Font = font;
                    float EF = (float)Convert.ToDouble(dane[25]);
                    font = new Font("Microsoft YaHei UI", EF);
                    txt_1.Font = font;
                    saveFileDialog1.FileName = "";
                    openFileDialog1.FileName = "";
                    cmd = dane[28];
                    closeaftercmd = Convert.ToBoolean(dane[29]);
                }
                catch (Exception ex) { ToLog(ex.ToString()); }
            }
            saveFileDialog1.FileName = "";
            openFileDialog1.FileName = "";
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.FromArgb(0, 120, 215);
            this.BackColor = colorDialog1.Color;
            txt_2.BackColor = colorDialog1.Color;
            txt_5.BackColor = colorDialog1.Color;
            txt_6.BackColor = colorDialog1.Color;
            txt_7.BackColor = colorDialog1.Color;
            txt_8.BackColor = colorDialog1.Color;
            txt_1.BackColor = colorDialog1.Color;
            txt_3.BackColor = colorDialog1.Color;
            txt_4.BackColor = colorDialog1.Color;
        }

        private void BSOD_EDIT_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (password_in.Text != textBox7.Text && BSOD_Timer.Enabled && unsafemode) e.Cancel = true;
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            timer3.Stop();
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
                txt_2.BackColor = colorDialog1.Color;
                txt_5.BackColor = colorDialog1.Color;
                txt_6.BackColor = colorDialog1.Color;
                txt_7.BackColor = colorDialog1.Color;
                txt_8.BackColor = colorDialog1.Color;
                txt_1.BackColor = colorDialog1.Color;
                txt_3.BackColor = colorDialog1.Color;
                txt_4.BackColor = colorDialog1.Color;
            }
        }

        private void rESETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.FromArgb(0, 120, 215);
            this.BackColor = colorDialog1.Color;
            txt_2.BackColor = colorDialog1.Color;
            txt_5.BackColor = colorDialog1.Color;
            txt_6.BackColor = colorDialog1.Color;
            txt_7.BackColor = colorDialog1.Color;
            txt_8.BackColor = colorDialog1.Color;
            txt_1.BackColor = colorDialog1.Color;
            txt_3.BackColor = colorDialog1.Color;
            txt_4.BackColor = colorDialog1.Color;
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
            Settings settings = new Settings(unsafemode, !pictureBox1.Visible, savepatch, txt_2.Font.Size, txt_6.Font.Size, txt_1.Font.Size, cmd, closeaftercmd, cmin, cmax, tmin, tmax);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                unsafemode = settings.unsmode.Checked;
                float MF = (float)settings.MFont.Value;
                Font font = new Font("Microsoft JhengHei UI Light", MF);
                txt_2.Font = font;
                txt_5.Font = font;
                txt_3.Font = font;
                txt_4.Font = font;
                float QF = (float)settings.QRFont.Value;
                font = new Font("Microsoft JhengHei UI Light", QF);
                txt_6.Font = font;
                txt_7.Font = font;
                txt_8.Font = font;
                float EF = (float)settings.EFont.Value;
                font = new Font("Microsoft YaHei UI", EF);
                txt_1.Font = font;
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (BSOD_Timer.Enabled) e.Cancel = true;
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
        public static void FormatVar(this RichTextBox r, string var, object value)
        {
            string vl = value.ToString();
            var = "{" + var + "}";
            string txt = r.Text.Replace(var, vl);
            r.Text = txt;
        }
    }
}
