using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WikipediaNet;

namespace FTP_CONSOLE
{
    public class Commands
    {
        public static class EXAMPLE
        {
            public static List<string> usages = new string[] { "" }.ToList();
            public static string Run(List<string> args)
            {
                if (args.Count > 1 && args[1].Length > 0)
                {
                    if (Program.GetArgs(args, 1) != "EXAMPLE")
                    {

                    }
                }
                else Program.WriteUSAGE("EXAMPLE", usages);
                return "";
            }
        }

        public static class WIKISEARCH
        {
            static int max = 5;
            static int mode = 0;
            static int mask = 0;
            public static List<string> usages = new string[] { "#max <value>", "#mode <value>", "#mask <value>", "<querry>" }.ToList();
            public static List<string> modeusages = new string[] { "0 - text", "1 - copy to clipboard", "2 - message box (all in one)", "3 - message box (all in separate)" }.ToList();
            public static string Run(List<string> args)
            {
                string result = "";
                if (LOGIN.loged)
                {
                    if (args.Count < 2 || args[1].Length <= 0) { Program.WriteUSAGE("wikisearch", usages); return ""; }
                    if (args.Count > 1)
                    {
                        if (Program.GetArgs(args, 1).ToLower() == "#max")
                        {
                            if (args.Count > 2 && Program.GetArgs(args, 2).Length > 0)
                            {
                                SetMax(args);
                            }
                            else
                            {
                                Program.WriteTxt($"&eMax is : {max}");

                            }
                            return "";
                        }
                        if (Program.GetArgs(args, 1).ToLower() == "#mode")
                        {
                            if (args.Count > 2 && Program.GetArgs(args, 2).Length > 0)
                            {
                                SetMode(args);
                            }
                            else
                            {
                                Program.WriteTxt($"&eMode is : {mode}");
                                Program.WriteUSAGE("wikisearch #mode", modeusages);
                            }
                            return "";
                        }
                        if (Program.GetArgs(args, 1).ToLower() == "#mask")
                        {
                            if (args.Count > 2 && Program.GetArgs(args, 2).Length > 0)
                            {
                                SetMask(args);
                            }
                            else
                            {
                                Program.WriteTxt($"&eMask is : {mask}");
                            }
                            return "";
                        }
                    }
                    if (args.Count > 1 && Program.GetArgs(args, 1).ToLower().Length > 0) Search(args); else { Program.WriteUSAGE("wikisearch", usages); }
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
            public static string SetMask(List<string> args)
            {
                if (LOGIN.loged)
                {
                    mask = Convert.ToInt32(Program.GetArgs(args, 2));
                    Program.WriteTxt($"&eMask Set to : {mask}");
                }
                return "";
            }
            public static string Search(List<string> args)
            {
                Wikipedia w = new Wikipedia(WikipediaNet.Enums.Language.Polish);
                string q = Program.GetArgs(args, 1, -1);
                var rs = w.Search(q);

                int rstof = rs.Search.Count;

                if (rs.Search.Count > max) rstof = max;
                if (max == -1) rstof = rs.Search.Count;
                List<string> results = new List<string>();
                for (int i = 0; i < rstof; i++)
                {
                    string raw = rs.Search[i].Snippet;
                    string f = raw.Replace("<span class=\"searchmatch\">", "");
                    f = f.Replace("</span>", "");
                    f = Program.MaskString(f, mask);
                    if (mode == 0)
                    {
                        foreach (var item in CLCODE.codes)
                        {
                            f = f.Replace("&" + item, @"\&" + item);
                        }
                        results.Add("&d" + f);
                    }
                    if (mode != 0)
                    {
                        results.Add(f);
                    }
                }
                if (mode == 0)
                {
                    Program.WriteTxt("&e&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&aWS RESULTS&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");
                    Program.WriteTxt(Program.GetArgs(results, 0, -1));
                    Program.WriteTxt("&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");
                }
                if (mode == 1)
                {
                    Clipboard.SetText(Program.GetArgs(results, 0, -1));
                }
                if (mode == 2)
                {
                    MessageBox.Show(Program.GetArgs(results, 0, -1), "Results");
                }
                if (mode == 3)
                {
                    for (int i = 0; i < results.Count; i++)
                    {
                        MessageBox.Show(results[i], $"Result {i + 1}/{results.Count}");
                    }
                }

                return "";
            }
            public static string SetMode(List<string> args)
            {
                if (LOGIN.loged)
                {
                    mode = Convert.ToInt32(Program.GetArgs(args, 2));
                    Program.WriteTxt($"&eMode Set to : {mode}");
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
                Program.WriteTxt("&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&aCREDENTIALS&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");

                Program.WriteTxt($"&9HOST     :: &b{FTPHandle.adres}");

                Program.WriteTxt($"&9LOGIN    :: &b{FTPHandle.credential.UserName}");

                if (LOGIN.loged)
                    Program.WriteTxt($"&9PASSWORD :: &b{FTPHandle.credential.Password}");

                else Program.WriteTxt($"&9PASSWORD :: &b*********");

                Program.WriteUSAGE("credentials", usages);
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
                Program.WriteTxt("&e&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&aFILE LIST&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");
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
                        tmp += "--";
                    }
                    string txt = $"&8{tmp}&2{item.FullName.Trim('/')}";
                    if (item.Type == FluentFTP.FtpFileSystemObjectType.File)
                    {
                        txt = txt.Replace(txt.Split('/')[txt.Split('/').Length - 1], $"&a{txt.Split('/')[txt.Split('/').Length - 1]}&2");
                    }
                    txt = txt.Replace("/", "&6/&2");
                    if (txt.Contains('.'))
                        txt = txt.Replace(txt.Split('.')[txt.Split('.').Length - 1], $"&e{txt.Split('.')[txt.Split('.').Length - 1]}");
                    txt = txt.Replace(".", "&b.&2");
                    Program.WriteTxt(txt);
                }
                Program.WriteTxt("&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");

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
                else if (args.Count > 1 && Program.GetArgs(args, 1, 1).ToLower() == "showimg") { if (args.Count < 3 || Program.GetArgs(args, 2).ToLower().Length < 1) Program.WriteUSAGE("gui", usages); }
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
        public static class WINCMD
        {
            public static List<string> usages = new string[] { "<command>", "wifi-list", "wifi-info <name>" }.ToList();
            public static string Run(List<string> args)
            {
                if (args.Count > 1 && args[1].Length > 0)
                {
                    if (args[1] != "wifi-list" && args[1] != "wifi-info") RunCMD(args);
                    if (args[1] == "wifi-list") RunCMD(new string[] { args[1], "netsh wlan show profile" }.ToList());
                    if (args[1] == "wifi-info") if (args.Count > 2) RunCMD(new string[] { args[1], $"netsh wlan show profile {args[2]} key=clear" }.ToList()); else Program.WriteUSAGE("wincmd", usages);
                }
                else Program.WriteUSAGE("wincmd", usages);
                return "";
            }
            public static string RunCMD(List<string> args)
            {
                void cwrite(string d)
                {
                    //Thread.Sleep(1);
                    if (d != null)
                    {
                        if (args[0] == "wifi-info")
                        {
                            d = d.Replace("Key Content            : ", "Key Content            : &5");
                            d = d.Replace("Name                   : ", "Name                   : &5");
                            d = d.Replace("SSID name              : ", "SSID name              : &5");
                        }
                        d = d.Replace(": ", "&a: &6");
                        Program.WriteTxt("&3" + d);
                    }

                }
                var p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = $"/c {Program.GetArgs(args, 1, -1)}";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.UseShellExecute = false;
                p.OutputDataReceived += (a, b) => cwrite(b.Data);
                p.ErrorDataReceived += (a, b) => cwrite(b.Data);
                p.Start();
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                p.WaitForExit();
                return "";
            }
        }
        public static class CID
        {
            public static List<string> tosend = new List<string>();
            public static List<string> unread = new List<string>();
            public static int lastreadline = 0;
            public static int client_id = new Random().Next(100000, 999999);
            public static List<string> usages = new string[] { "read", "get", "renew", "send <cid> <message>", "send * <message>", "info" }.ToList();
            public static string Run(List<string> args)
            {
                if (args.Count > 1)
                {
                    if (args[1] == "renew") { client_id = new Random().Next(100000, 999999); Program.WriteTxt($"&bYour new CID is : &5{client_id}"); }
                    if (args[1] == "send") Send(args);
                    if (args[1] == "read") Synch();
                    if (args[1] == "info") Info();
                    if (args[1] == "reset") Reset();
                    if (args[1] == "remove") Remove();
                    if (args[1] == "response") Resp(args);
                }
                else Program.WriteUSAGE("cid", usages);
                return "";
            }
            public static string Init(List<string> args)
            {
                lastreadline = FTPHandle.GetCIDLenght();
                Reset();
                Commands.CID.DownloadAll();
                Commands.CLEAR.ClearOneLine();
                return "";
            }
            public static string Resp(List<string> args)
            {
                DateTime d = DateTime.Now;
                CID.Send(new string[] { "", "", client_id.ToString(), "&5Resp&6#&5Resp" }.ToList());
                CID.DownloadAll();
                for (int i = 0; i < unread.Count; i++)
                {
                    if (unread[i].Contains("&5Resp&6#&5Resp"))
                    {
                        DateTime d1 = DateTime.Now;
                        TimeSpan diff = d1 - d;
                        Program.WriteTxt("&aResponse : ");
                        Program.WriteTxt("  &aSent    : &5" + d.ToString("HH:mm:ss:ff"));
                        Program.WriteTxt("  &aRecived : &5" + d1.ToString("HH:mm:ss:ff"));
                        Program.WriteTxt("  &aOffset  : &5" + Math.Round(diff.TotalMilliseconds, 0) + "ms");
                        unread.Remove(unread[i]);
                        return "";
                    }
                    else Program.WriteTxt("&4Message not recived");
                }

                return "";
            }
            public static string Send(List<string> args)
            {
                if (args.Count >= 4 && args[2].Length > 0 && args[3].Length > 0)
                {
                    if (args[2].Trim() == "*")
                    {
                        tosend.Add(Program.GetArgs(args, 3, -1) + "#to*all#" + $"#from#:[{client_id}]");
                    }
                    else if (args[2].Length == 6)
                    {
                        tosend.Add(Program.GetArgs(args, 3, -1) + "#to" + args[2] + "#" + $"#from#:[{client_id}]");
                    }
                }
                else Program.WriteUSAGE("cid", usages);
                SendAll();
                return "";
            }
            public static string Read()
            {
                Program.WriteTxt("&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&aREADING&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");
                foreach (var item in unread)
                {
                    Program.WriteTxt(item);
                }
                if (unread.Count < 1) Program.WriteTxt("&4Nothing to read!");
                unread.Clear();
                Program.WriteTxt("&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&aREADING&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");
                return "";
            }
            public static string Remove()
            {
                FTPHandle.CIDRemove();
                Reset();
                return "";
            }
            public static string Reset()
            {
                tosend.Clear();
                unread.Clear();
                lastreadline = 0;
                return "";
            }
            public static string Info()
            {
                DownloadAll();
                Program.WriteTxt("&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&aCID-INFO&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");
                Program.WriteTxt($"&3CID : &5{client_id}");
                Program.WriteTxt($"&3Position : &5{lastreadline} / &b{FTPHandle.GetCIDLenght()}");
                Program.WriteTxt($"&3Buffor : ");
                Program.WriteTxt($"&3     Read : &5{unread.Count}");
                Program.WriteTxt($"&3     Send : &5{tosend.Count}");
                Program.WriteTxt("&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&aCID-INFO&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=&a-&4=");
                return "";
            }
            public static void Synch()
            {
                DownloadAll();
                Read();
            }
            public static void DownloadAll(bool slow, bool report = true)
            {
                int cidlenght = FTPHandle.GetCIDLenght();
                if (report) Program.WriteTxt($"&4CID Download : [{lastreadline}]/[{cidlenght}]");
                FTPHandle.ftp.Disconnect();
                while (cidlenght > lastreadline)
                {
                    string txt = FTPHandle.GetCIDTxt(lastreadline + 1);
                    if (txt.Contains("#to*all#") || txt.Contains("#to" + client_id + "#"))
                    {
                        txt = txt.Replace("#to*all#", "");
                        txt = txt.Replace("#to" + client_id + "#", "");
                        unread.Add(txt);
                    }
                    lastreadline++;
                    if (report) CLEAR.ClearOneLine();
                    if (report) Program.WriteTxt($"&4CID Download : [{lastreadline}]/[{cidlenght}]");
                }
            }
            public static void DownloadAll(bool report = true)
            {
                int cidlenght = FTPHandle.GetCIDLenght();
                List<string> list = FTPHandle.GetCIDList();
                if (report) Program.WriteTxt($"&4CID Download : [{lastreadline}]/[{cidlenght}]");
                while (cidlenght > lastreadline)
                {
                    string txt = list[lastreadline];
                    if (txt.Contains("#to*all#") || txt.Contains("#to" + client_id + "#"))
                    {
                        txt = txt.Replace("#to*all#", "");
                        txt = txt.Replace("#to" + client_id + "#", "");
                        string fcid = txt[txt.Length - 7].ToString() + txt[txt.Length - 6].ToString() + txt[txt.Length - 5].ToString() + txt[txt.Length - 4].ToString() + txt[txt.Length - 3].ToString() + txt[txt.Length - 2].ToString();
                        fcid = fcid.Replace(client_id.ToString(), $"{client_id} &5(YOU)");
                        txt = txt.Remove(txt.Length - 15, 15);
                        // #from#:[123456]
                        unread.Add($"&e{fcid} &b: &f" + txt);
                    }
                    lastreadline++;
                    if (report) CLEAR.ClearOneLine();
                    if (report) Program.WriteTxt($"&4CID Download : [{lastreadline}]/[{cidlenght}]");
                }
            }
            public static void SendAll(bool report = true)
            {
                int done = 0;
                foreach (var item in tosend)
                {
                    done++;
                    if (report) Program.WriteTxt($"&4CID Upload : [{done}]/[{tosend.Count}]");
                    FTPHandle.AppCIDTxt(item);
                }
                tosend.Clear();
            }
        }
        public static class UPDATES
        {
            public static string newpatch = "";
            public static Uri batchURL;
            public static Uri update_url;
            public static bool uptodate = false;
            public static bool dev = false;
            public static Version installed;
            public static Version remote;
            public static string token = "?client_id=9a3e58501214628adc6d&client_secret=9f30900fad7b567e1c59e931f0518cedc8aec68c";
            class GitHubRelease
            {
                [JsonProperty("tag_name")]
                public string Tag { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("published_at")]
                public string ReleaseTime { get; set; }

                [JsonProperty("body")]
                public string Description { get; set; }
            }
            public static void CheckUpdates()
            {
                try
                {
                    uptodate = true;
                    dev = false;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    WebClient wc = new WebClient();
                    wc.Headers.Add("User-Agent", "request");
                    var json = wc.DownloadString(new Uri("https://api.github.com/repos/dommilosz/FTP-SCREEN-SHOT-CONSOLE/releases/latest" + token));
                    GitHubRelease latest = JsonConvert.DeserializeObject<GitHubRelease>(json);
                    string latestVersion = latest.Tag,
                    currentVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
                    installed = System.Version.Parse(currentVersion);
                    remote = System.Version.Parse(latestVersion);
                    update_url = new Uri(@"https://github.com/dommilosz/FTP-SCREEN-SHOT-CONSOLE/releases/download/" + latest.Tag + "/FTP-CONSOLE.exe" + token);
                    newpatch = Application.ExecutablePath.Replace(".exe", "_" + latest.Tag + ".exe");
                    batchURL = new Uri(@"https://github.com/dommilosz/FTP-SCREEN-SHOT-CONSOLE/releases/download/SV/Update.bat" + token);
                    if (Application.ProductVersion.Contains("DEV"))
                    {
                        Program.WriteTxt($"&aYou are Using &5DEV&a Version! ");
                        dev = true;
                        return;
                    }
                    if (installed < remote)
                    {
                        Program.WriteTxt($"&2Found update: &c{installed}&5 -----> &b{remote}");
                        Program.WriteTxt($"&2Download : &5/update download");
                        uptodate = false;
                    }
                    else Program.WriteTxt($"&aYou are Up To Date! &5({installed})");
                }
                catch { }
            }
            public static string Run(List<string> args)
            {
                if (args.Count > 1 && args[1].Length > 0)
                {
                    if (args[1].Trim().ToLower() == "download") { Update(); }
                }
                else { CheckUpdates(); }
                return "";
            }
            public static string Update()
            {
                CheckUpdates();
                if (uptodate || dev)
                {

                    Program.WriteTxt($"&4Do You Want To Reinstall FTP-CONSOLE? &aY/N  : ", false);
                    string ans = Console.ReadKey().KeyChar.ToString().ToLower();
                    Program.WriteTxt("");
                    if (ans == "y")
                    {

                    }
                    else { return ""; }
                }
                Program.WriteTxt($"&2Downloading Updates!");
                string exec = Application.ExecutablePath.Replace(Application.StartupPath, "");
                string execnew = newpatch.Replace(Application.StartupPath, "");
                exec = exec.TrimStart(@"\".ToCharArray()[0]);
                execnew = execnew.TrimStart(@"\".ToCharArray()[0]);
                WebClient w = new WebClient();
                string args = "\"" + execnew + "\" \"" + exec + "\"";
                w.DownloadFile(update_url, newpatch);
                w.DownloadFile(batchURL, Application.StartupPath + "Update.bat");
                Thread.Sleep(2000);
                Process.Start(Application.StartupPath + "Update.bat", args);
                Application.Exit();
                return "";
            }
        }
        public static class BSOD
        {
            public static List<string> usages = new string[] { "editor" }.ToList();
            public static string Run(List<string> args)
            {
                if (args.Count > 1 && args[1].Length > 0)
                {
                    if (Program.GetArgs(args,1).ToLower() =="editor")
                    {
                        BlueScreen_Simulator.BSOD_EDIT b = new BlueScreen_Simulator.BSOD_EDIT();
                        b.ShowDialog();
                    }
                }
                else Program.WriteUSAGE("bsod", usages);
                return "";
            }
        }
    }
}
