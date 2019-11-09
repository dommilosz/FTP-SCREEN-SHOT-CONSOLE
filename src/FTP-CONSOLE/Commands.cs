﻿using PREVIEW;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WikipediaNet;

namespace FTP_CONSOLE
{
    public class Commands
    {
        public static class WIKISEARCH
        {
            static int max = 5;
            public static List<string> usages = new string[] { "#max <value>", "<querry>" }.ToList();
            public static string Run(List<string> args)
            {
                string result = "";
                if (LOGIN.loged)
                {
                    if (args.Count < 2) { Program.WriteUSAGE("wikisearch", usages); return ""; }
                    if (args.Count > 1 && Program.GetArgs(args, 1).ToLower() == "#max")
                    {
                        if (args.Count > 2 && Program.GetArgs(args, 2).Length > 0 )
                        {
                            SetMax(args);
                        }
                        else
                        {
                            Program.WriteTxt($"&eMax is : {max}");

                        }
                        return "";
                    }
                    else { if (Program.GetArgs(args, 1).ToLower() != "#max" && args.Count > 1 && Program.GetArgs(args, 1).ToLower().Length > 0) Search(args); else { Program.WriteUSAGE("wikisearch", usages); } }
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
            public static string Search(List<string> args)
            {
                Wikipedia w = new Wikipedia(WikipediaNet.Enums.Language.Polish);
                string q = Program.GetArgs(args, 1, -1);
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
            public static List<string> usages = new string[] { "setpass <newpass>", "setlogin <newlogin>", "sethost <newhost>", "reset", "test" }.ToList();
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

                Program.WriteUSAGE("credentials", usages);
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
                if (FTPHandle.ftp.IsConnected)
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
            public static string codes = "0123456789abcdef";
            public static string Run(List<string> args)
            {
                string msg1 = @"@&f\&0 - BLACK       @&4\&4 - DARK RED      @&8\&8 - DARK GRAY   @&c\&c - RED";
                string msg2 = @"@&1\&1 - DARK BLUE   @&5\&5 - DARK PURPLE   @&9\&9 - BLUE        @&d\&d - PURPLE";
                string msg3 = @"@&2\&2 - DARK GREEN  @&6\&6 - GOLD          @&a\&a - GREEN       @&e\&e - YELLOW";
                string msg4 = @"@&3\&3 - DARK AQUA   @&7\&7 - GRAY          @&b\&b - AQUA        @&f\&f - WHITE";
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
            public static List<string> usages = new string[] { "full <patch>", "selection <patch>", "sel <patch>" }.ToList();
            public static string Run(List<string> args)
            {
                if (args.Count < 3 || Program.GetArgs(args, 1, 1).ToLower() != "full" && Program.GetArgs(args, 1, 1).ToLower() != "sel" && Program.GetArgs(args, 1, 1).ToLower() != "selection" || Program.GetArgs(args, 2).ToLower().Length < 1) { Program.WriteUSAGE("screenshot", usages); return ""; }
                if (Program.GetArgs(args, 1, 1).ToLower() == "full")
                {
                    Full(args);
                }
                if (Program.GetArgs(args, 1, 1).ToLower() == "selection" || Program.GetArgs(args, 1, 1).ToLower() == "sel")
                {
                    Selection(args);
                }

                return "";
            }
            public static string Full(List<string> args)
            {
                string name = Program.GetArgs(args, 2, -1);
                name = "0RootScreenShot08/" + name;
                var canvas = CANVAS.Canvas.Open();
                FTPHandle.FTPSend(canvas.ScreenS(), name);
                canvas.Dispose();
                return "";
            }
            public static string Selection(List<string> args)
            {
                string name = Program.GetArgs(args, 2, -1);
                name = "0RootScreenShot08/" + name;
                var canvas = CANVAS.Canvas.Open();
                if (canvas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    FTPHandle.FTPSend(canvas.image, name);
                canvas.Dispose();
                return "";
            }
        }
        public static class TREE
        {
            public static List<FluentFTP.FtpListItem> Run(List<string> args)
            {
                Program.WriteTxt("&e::LISTING::");
                var list = FTPHandle.GetItemsList("0RootScreenShot08/");

                foreach (var item in list)
                {
                    CLEAR.ClearOneLine();
                }
                foreach (var item in list)
                {
                    string tmp = "";
                    for (int i = 0; i < item.FullName.Split("/"[0]).Length - 2; i++)
                    {
                        tmp += "---";
                    }
                    Program.WriteTxt($"&8{tmp}&2{item.FullName.Trim('/')}");
                }
                Program.WriteTxt("&e::LISTING::");

                return list;
            }
        }
        public static class GUI
        {
            public static List<string> usages = new string[] { "gui", "gui old", "showimg <patch>" }.ToList();
            public static string Run(List<string> args)
            {
                if (args.Count < 2 || Program.GetArgs(args, 1, 1).ToLower() != "showimg" && Program.GetArgs(args, 1, 1).ToLower() != "gui")
                {
                    Program.WriteUSAGE("gui", usages);
                    return "";
                }
                if (args.Count > 2 && Program.GetArgs(args, 1, 1).ToLower() == "showimg" && Program.GetArgs(args, 2).ToLower().Length > 0)
                {
                    Showimg(args);
                }
                else if (args.Count < 3 || Program.GetArgs(args, 2).ToLower().Length < 1) Program.WriteUSAGE("gui", usages);
                if (Program.GetArgs(args, 1, -2).ToLower() == "gui")
                {
                    if (args.Count > 2 && Program.GetArgs(args, 2, -2).ToLower() == "oldconsole" || Program.GetArgs(args, 2, -1).ToLower() == "old")
                    {
                        ShowGUIOld(args);
                    }
                    else
                        ShowGUI(args);
                }

                return "";
            }
            public static string Showimg(List<string> args)
            {
                if (args.Count > 2)
                {
                    string patch = Program.GetArgs(args, 2, -1, "/");
                    patch = "0RootScreenShot08/" + patch;
                    var img = FTPHandle.DownloadImage(patch);
                    PREVIEW.PREVIEW.Open().Show(img);
                }
                return "";
            }
            public static string ShowGUI(List<string> args)
            {
                Program.ShowWindow(Program.GetConsoleWindow(), Program.SW_HIDE);
                var tmp = new FTPScreenShot.MainWindow(true);
                tmp.ShowDialog();
                Program.ShowWindow(Program.GetConsoleWindow(), Program.SW_SHOW);
                return "";
            }
            public static string ShowGUIOld(List<string> args)
            {
                Program.ShowWindow(Program.GetConsoleWindow(), Program.SW_HIDE);
                var tmp = new FTPScreenShot.MainWindow(true);
                tmp.newconsole = false;
                tmp.ShowDialog();
                Program.ShowWindow(Program.GetConsoleWindow(), Program.SW_SHOW);
                return "";
            }
        }
        public static class DOWNLOAD
        {
            public static string Run(List<string> args)
            {
                FTPHandle.DownloadAll(TREE.Run(args));
                return "";
            }
        }
        public static class DELETE
        {
            public static List<string> usages = new string[] { "<patch>", "*" }.ToList();
            public static string Run(List<string> args)
            {
                if (args.Count > 1 && Program.GetArgs(args, 1).Length > 0)
                {
                    if (("0RootScreenShot08/" + Program.GetArgs(args, 1, -1)).Length > 0)
                        FTPHandle.FTPDelete("0RootScreenShot08/" + Program.GetArgs(args, 1, -1));
                }
                else Program.WriteUSAGE("delete", usages);
                return "";
            }
        }
        public static class COLOR
        {
            public static char color = '-';
            public static string Run(List<string> args)
            {
                SET(args);
                return "";
            }
            public static string SET(List<string> args)
            {
                char c = '-';
                char c2 = '-';
                if (args.Count > 1 && Program.GetArgs(args, 1, 1).ToLower().Length > 0)
                {
                    if (Program.GetArgs(args, 1, 1).ToLower().Length > 1)
                    {
                        c = Program.GetArgs(args, 1, 1).ToLower()[1];
                    }
                    c2 = Program.GetArgs(args, 1, 1).ToLower()[0];
                    if (CLCODE.codes.Contains(c))
                    {
                        color = c;
                        Program.WriteTxt(@"&2Colors Turned To : \&" + c);
                    }
                    else if (CLCODE.codes.Contains(c2))
                    {
                        color = c2;
                        Program.WriteTxt(@"&2Colors Turned To : \&" + c2);
                    }
                    else { color = '-'; Program.WriteTxt(@"&2Colors Reset : \&f"); }
                }
                else { color = '-'; Program.WriteTxt(@"&2Colors Reset : \&f"); }
                return "";
            }

        }
        public static class EXIT
        {
            public static string Run(List<string> args)
            {
                Program.WriteTxt("&5Press Any Key To Exit...");
                Program.WriteTxt("&5Press [ESC] to Cancel");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                    Environment.Exit(0);
                Program.WriteTxt("");
                CLEAR.ClearOneLine();
                return "";
            }
        }
    }
}
