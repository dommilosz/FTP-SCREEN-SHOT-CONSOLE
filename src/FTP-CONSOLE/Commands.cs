using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikipediaNet;

namespace FTP_CONSOLE
{
    public class Commands
    {
        public static class WIKISEARCH
        {
            static int max = 5;
            public static string Run(List<string> args)
            {
                string result = "";
                if (LOGIN.loged)
                {
                    if (Program.GetArgs(args, 1).ToLower() == "#max")
                    {
                        SetMax(args);
                        return "";
                    }

                    Wikipedia w = new Wikipedia(WikipediaNet.Enums.Language.Polish);
                    string q = Program.GetArgs(args, 1, -1);
                    if (q.Length == 0) { throw new Exception("Querry can not be null"); return ""; }
                    var rs = w.Search(q);
                    Program.WriteTxt("&e::Results::");
                    int rstof = rs.Search.Count;
                    if (rs.Search.Count > max) rstof = max;
                    for (int i = 0; i < rstof; i++)
                    {
                        string raw = rs.Search[i].Snippet;
                        string f = raw.Replace("<span class=\"searchmatch\">", "");
                        f = f.Replace("</span>", "");
                        Program.WriteTxt("&d" + f);
                    }
                    Program.WriteTxt("&e::Results::");
                }
                else { throw new Exception("Unknown Command"); }
                return result;
            }
            public static string SetMax(List<string> args)
            {
                if (LOGIN.loged)
                {
                    max = Convert.ToInt32(Program.GetArgs(args, 2));
                    Program.WriteTxt($"&eMax Set to : {max}");
                }
                return "";
            }
        }
        public static class CLEAR
        {
            public static string Run(List<string> args)
            {
                Console.Clear();
                return "";
            }
            public static void ClearOneLine()
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }
        public static class LOGIN
        {
            public static bool loged = false;
            public static string Run(List<string> args)
            {
                CLEAR.ClearOneLine();
                if (Program.GetArgs(args, 1, -1) == "4628")
                {
                    loged = true;
                }
                if (Program.GetArgs(args, 1).ToLower() == "lo")
                {
                    loged = false;
                }
                if (loged)
                    Program.WriteTxt($"&aLogged : {loged}");
                else
                    Program.WriteTxt($"&4Logged : {loged}");
                return "";
            }
        }
        public static class CREDENTIALS
        {
            public static string Run(List<string> args)
            {
                if (args.Count > 1)
                {
                    if (Program.GetArgs(args, 1).ToLower() == "setpass")
                    {
                        if (args.Count > 2)
                        {
                            SetPass(args); return "";
                        }
                        else throw new Exception("Give more parameters");
                    }
                    if (Program.GetArgs(args, 1).ToLower() == "setlogin")
                    {
                        if (args.Count > 2)
                        {
                            SetLogin(args); return "";
                        }
                        else throw new Exception("Give more parameters");
                    }
                    if (Program.GetArgs(args, 1).ToLower() == "sethost")
                    {
                        if (args.Count > 2)
                        {
                            SetHost(args); return "";
                        }
                        else throw new Exception("Give more parameters");
                    }
                    if (Program.GetArgs(args, 1).ToLower() == "reset") { SetToDefault(args); return ""; }
                    if (Program.GetArgs(args, 1).ToLower() == "test") { Test(args); return ""; }
                    FTPHandle.ReloadCredentials();
                }
                Program.WriteTxt("&e::CREDENTIALS::");

                Program.WriteTxt($"&9HOST     :: &b{FTPHandle.adres}");

                Program.WriteTxt($"&9LOGIN    :: &b{FTPHandle.credential.UserName}");

                if (LOGIN.loged)
                    Program.WriteTxt($"&9PASSWORD :: &b{FTPHandle.credential.Password}");

                else Program.WriteTxt($"&9PASSWORD :: &b*********");

                Program.WriteTxt("&e::CREDENTIALS::");
                return "";
            }
            public static string SetPass(List<string> args)
            {
                FTPHandle.credential.Password = Program.GetArgs(args, 2, -1);
                Program.WriteTxt($"&ePassword Changed to : {FTPHandle.credential.Password}");
                return "";
            }
            public static string SetLogin(List<string> args)
            {
                FTPHandle.credential.UserName = Program.GetArgs(args, 2, -1);
                Program.WriteTxt($"&eLogin Changed to : {FTPHandle.credential.UserName}");
                return "";
            }
            public static string SetHost(List<string> args)
            {
                FTPHandle.adres = Program.GetArgs(args, 2, -1);
                Program.WriteTxt($"&eLogin Changed to : {FTPHandle.adres}");
                return "";
            }
            public static string SetToDefault(List<string> args)
            {
                FTPHandle.ResetToFactory();
                Program.WriteTxt($"&eCredentials Changed to default");
                return "";
            }
            public static string Test(List<string> args)
            {
                Program.WriteTxt($"&eTesting...");
                FTPHandle.ftp.Connect();
                if(FTPHandle.ftp.IsConnected)
                FTPHandle.ftp.Disconnect();
                Program.WriteTxt($"&2Test Passed!");
                return "";
            }
        }
        public static class WRITECMD
        {
            public static string Run(List<string> args)
            {
                CLEAR.ClearOneLine();
                Program.WriteTxt(Program.GetArgs(args, 1, -1));
                return "";
            }
        }
        public static class CLCODE
        {
            public static string Run(List<string> args)
            {
                string codes = "0123456789abcdef";
                string msg1 = @"\&0 - BLACK       &4\&4 - DARK RED      &8\&8 - DARK GRAY   &c\&c - RED";
                string msg2 = @"&1\&1 - DARK BLUE   &5\&4 - DARK PURPLE   &9\&9 - BLUE        &d\&d - PURPLE";
                string msg3 = @"&2\&2 - DARK GREEN  &6\&4 - GOLD          &a\&a - GREEN       &e\&e - YELLOW";
                string msg4 = @"&3\&3 - DARK AQUA   &7\&4 - GRAY          &b\&b - AQUA        &f\&f - WHITE";
                Program.WriteTxt("&e::COLOR:CODES::");
                Program.WriteTxt(msg1);
                Program.WriteTxt(msg2);
                Program.WriteTxt(msg3);
                Program.WriteTxt(msg4);
                Program.WriteTxt("&e::COLOR:CODES::");
                return "";
            }
        }
        public static class SCREENSHOT
        {
            public static string Run(List<string> args)
            {
                if (Program.GetArgs(args, 1, 1).ToLower() == "full")
                {
                    Full(args);
                }
                if (Program.GetArgs(args, 1, 1).ToLower() == "selection")
                {
                    Selection(args);
                }
                return "";
            }
            public static string Full(List<string> args)
            {
                string name = Program.GetArgs(args, 2, -1);
                var canvas = CANVAS.Canvas.Open();
                FTPHandle.FTPSend(canvas.ScreenS(),name);
                canvas.Dispose();
                return "";
            }
            public static string Selection(List<string> args)
            {
                string name = Program.GetArgs(args, 2, -1);
                var canvas = CANVAS.Canvas.Open();
                if(canvas.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                FTPHandle.FTPSend(canvas.image, name);
                canvas.Dispose();
                return "";
            }
        }
        public static class TREE
        {
            public static string Run(List<string> args)
            {
                Program.WriteTxt("&e::LISTING::");
                var list = FTPHandle.GetItemsList();
                
                foreach (var item in list)
                {
                    CLEAR.ClearOneLine();
                }
                foreach (var item in list)
                {
                    string tmp = "";
                    for (int i = 0; i < item.FullName.Split("/"[0]).Length-1; i++)
                    {
                        tmp += "---";
                    }
                    Program.WriteTxt($"&8{tmp}&2{item.FullName.Trim('/')}");
                }
                Program.WriteTxt("&e::LISTING::");

                return "";
            }
        }
    }
}
