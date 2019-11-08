using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WikipediaNet;
using WikipediaNet.Objects;

namespace FTPScreenShot
{
    public partial class DevConsole : Form
    {
        static DevConsole d = new DevConsole();
        List<string> log = new List<string>();
        bool login = false;
        string password = "45628";
        int wikipediamax = 3;
        bool color = true;
        RichTextBox colorbck;
        public DevConsole()
        {
            InitializeComponent();
            colorbck = richTextBox1;
        }
        public DevConsole(string log)
        {
            InitializeComponent();
            colorbck = richTextBox1;
            Add(log);
        }

        private void DevConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Pause)
            {
                try
                {
                    textBox1.ResetText();
                    textBox1.AppendText(richTextBox1.SelectedText);
                }
                catch { }
            }
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    textBox1.ResetText();
                    textBox1.AppendText(log[log.Count - 1]);
                }
                catch { }
            }
        }

        public void SendCmd(string arg, bool user = false)
        {
            if (user)
            {
                log.Add(arg);
            }

            List<string> args = arg.Split(' ').ToList();
            string command = args[0];
            string GetArgs(int index, int to = -1)
            {
                string data = "";
                if (to == -1) to = 999999999;
                for (int i = 0; i < args.Count; i++)
                {
                    if (i >= index && i <= to)
                    {
                        data += args[i] + " ";
                    }
                }
                return data.TrimEnd();
            }

            if (arg.Split(' ')[0] == "echocl")
            {
                string color = arg.Split(' ')[1];
                Add(GetArgs(2), Color.FromName(color));
                return;
            }
            if (arg.Split(' ')[0] == "echoclcode")
            {
                try
                {
                    int R = Convert.ToInt32(arg.Split(' ')[1]);
                    int G = Convert.ToInt32(arg.Split(' ')[2]);
                    int B = Convert.ToInt32(arg.Split(' ')[3]);
                    Add(GetArgs(4), Color.FromArgb(R, G, B));
                }
                catch (Exception ex) { ResultsList.FromException(ex); }
                return;
            }
            if (arg.Split(' ')[0] == "echo")
            {
                Add(GetArgs(1));
                return;
            }
            if (arg.Split(' ')[0] == "ln")
            {
                if (GetArgs(1) == password)
                {
                    Add("Logged In!", Color.Lime);
                    login = true;
                    return;
                }
                if (GetArgs(1) == "logout")
                {
                    Add("Logged Out!", Color.Red);
                    login = false;
                    return;
                }
                Add("Bad Password!", Color.Red);
                return;
            }

            Add(" - " + arg, Color.Yellow);

            if (arg.Split(' ')[0] == "cd")
            {
                bool inoe = false;
                try
                {
                    var tmp = arg.Split(' ')[1];
                    if (tmp == " ") inoe = true;
                }
                catch { inoe = true; }
                if (inoe)
                {
                    List<FluentFTP.FtpListItem> items = FTPHandle.GetItemsList("/ScreenShot");
                    Add("Items In Dir : Main : ");
                    for (int i = 0; i < items.Count; i++)
                    {
                        Add(items[i].Name, Color.Violet);
                    }
                }
                else
                {
                    List<FluentFTP.FtpListItem> items = FTPHandle.GetItemsList("/ScreenShot/" + arg.Split(' ')[1]);
                    Add("Items In Dir : " + arg.Split(' ')[1] + " : ");
                    for (int i = 0; i < items.Count; i++)
                    {
                        Add(items[i].Name, Color.Violet);
                    }
                }
                return;
            }
            if (arg.Split(' ')[0] == "wshmax")
            {
                if (login)
                {
                    try
                    {
                        wikipediamax = Convert.ToInt32(arg.Split(' ')[1]);
                        Add("Limit set to " + wikipediamax.ToString(), Color.Lime);
                    }
                    catch
                    {

                        return;
                    }

                    return;
                }
            }
            if (arg.Split(' ')[0] == "color")
            {
                try
                {
                    if (arg.Split(' ')[1] == "1" || arg.Split(' ')[1] == "0")
                    {
                        if (arg.Split(' ')[1] == "1")
                            color = true;
                        if (arg.Split(' ')[1] == "0")
                            color = false;
                        Add("Color is " + color.ToString(), Color.Lime);
                    }
                    richTextBox1.Visible = color;
                    richTextBox2.Visible = !color;
                    richTextBox2.Text = richTextBox1.Text;
                    richTextBox2.SelectAll();
                    richTextBox2.SelectionColor = Color.Gray;
                    richTextBox2.DeselectAll();
                }
                catch
                {

                    return;
                }

                return;

            }
            if (arg.Split(' ')[0] == "wsearch" || arg.Split(' ')[0] == "wsh")
            {
                if (login)
                {
                    string querry = GetArgs(1);
                    try
                    {
                        Add("Searching : " + querry, Color.Aqua);
                        List<Search> searches = new List<Search>();
                        Wikipedia wikipedia = new Wikipedia(WikipediaNet.Enums.Language.Polish);
                        wikipedia.Limit = wikipediamax;
                        QueryResult result = wikipedia.Search(querry);
                        List<string> results = new List<string>();
                        foreach (Search s in result.Search)
                        {
                            searches.Add(s);
                            results.Add(s.Snippet);
                        }

                        for (int i = 0; i < results.Count; i++)
                        {
                            results[i] = results[i].Replace("<span class=\"searchmatch\">", "");
                            results[i] = results[i].Replace("</span>", "");
                        }
                        for (int i = 0; i < results.Count; i++)
                        {
                            Add(results[i], Color.Violet);
                        }

                    }
                    catch (Exception ex) { Add(ex.ToString()); }
                    return;
                }
            }
            if (arg.Split(' ')[0] == "clear" || arg.Split(' ')[0] == "cs")
            {
                richTextBox1.Text = "";
                log.Clear();
                return;
            }
            if (arg.Split(' ')[0] == "credentials")
            {
                if (args.Count > 1)
                {


                    if (args[1] == "reset")
                    {
                        FTPHandle.credential.Password = FTPHandle.haslo;
                        FTPHandle.credential.UserName = FTPHandle.login;
                        FTPHandle.adres = FTPHandle.adresfactory;
                        Add("Credentials changed to factory", Color.Violet);
                    }
                    if (args[1] == "ping")
                    {
                        try
                        {
                            FluentFTP.FtpClient f = new FluentFTP.FtpClient(FTPHandle.adres, FTPHandle.credential);
                            f.Connect();
                            f.Disconnect();
                            Add("Credentials ping succes", Color.Lime);
                        }
                        catch (Exception ex) { ResultsList.FromException(ex); Add("To reset write : credentials reset", Color.Violet); }
                        return;
                    }
                    if (args[1] == "changepass")
                    {
                        FTPHandle.credential.Password = GetArgs(2);
                        Add("Password changed to : " + GetArgs(2), Color.Violet);
                    }
                    if (args[1] == "changelogin")
                    {
                        FTPHandle.credential.UserName = GetArgs(2);
                        Add("Login changed to        : " + GetArgs(2), Color.Violet);
                    }
                    if (args[1] == "changehost")
                    {
                        FTPHandle.adres = GetArgs(2);
                        Add("Host changed to         : " + GetArgs(2), Color.Violet);
                    }

                }
                Add("Login Credentials", Color.Yellow);
                Add("Host         : " + FTPHandle.adres, Color.Violet);
                Add("Login        : " + FTPHandle.credential.UserName, Color.Violet);
                if (login) Add("Password : " + FTPHandle.credential.Password, Color.Violet);
                string passhide = "";
                for (int i = 0; i < FTPHandle.credential.Password.Length; i++)
                {
                    passhide += "*";
                }
                if (!login) Add("Password : " + passhide, Color.Violet);
                return;
            }
            if (arg.Length <= 0)
            {
                return;
            }
            Add("Null Command", Color.Red);
        }
        public void Add(string txt, Color color)
        {
            int start = richTextBox1.Text.Length;
            richTextBox1.AppendText(txt + Environment.NewLine);
            richTextBox1.Select(start, txt.Length);
            richTextBox1.SelectionColor = color;
            richTextBox1.DeselectAll();
            richTextBox2.Text = richTextBox1.Text;
        }
        public void Add(string txt)
        {
            Add(txt, Color.Gray);
        }
        public static void ShowConsole()
        {
            d.WindowState = FormWindowState.Normal;
            d.ShowInTaskbar = true;
            d.Show();
        }
        public static DevConsole ShowGetConsole()
        {
            d.WindowState = FormWindowState.Normal;
            d.ShowInTaskbar = true;
            d.Show();
            return d;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SendCmd(textBox1.Text, true);
            textBox1.Text = "";
        }

        private void DevConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            e.Cancel = true;
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // scroll it automatically
            richTextBox1.ScrollToCaret();
            richTextBox1.DeselectAll();
        }

        private void RCH_MUP(object sender, MouseEventArgs me)
        {
            RichTextBox rch = (RichTextBox)sender;
            RichTextBox rtb = (RichTextBox)sender;
            int LineUnderMouse()
            {
                int x = me.Location.X;
                int y = me.Location.Y;
                int pos = rch.GetCharIndexFromPosition(new Point(x, y));
                return richTextBox1.GetLineFromCharIndex(pos);
            }

            if (me.Button == MouseButtons.Right)
            {
                string linetmp = rch.Lines[LineUnderMouse()];
                List<char> chars = linetmp.ToArray().ToList();
                if (chars[1] == '-')
                {
                    chars.RemoveAt(0);
                    chars.RemoveAt(0);
                    chars.RemoveAt(0);

                    string comp = "";
                    for (int i = 0; i < chars.Count; i++)
                    {
                        comp += chars[i];
                    }

                    textBox1.ResetText();
                    textBox1.AppendText(comp);
                }
            }
        }
    }
}
