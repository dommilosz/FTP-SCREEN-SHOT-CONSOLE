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
                    if (Program.GetArgs(args, 1).ToLower().Trim() == "#max")
                    {
                        SetMax(args);
                        return "";
                    }
                    Program.WriteLn("::Results::", true, ConsoleColor.Yellow);
                    Wikipedia w = new Wikipedia(WikipediaNet.Enums.Language.Polish);
                    string q = Program.GetArgs(args, 1, -1);
                    var rs = w.Search(q);
                    int rstof = rs.Search.Count;
                    if (rs.Search.Count > max) rstof = max;
                    for (int i = 0; i < rstof; i++)
                    {
                        string raw = rs.Search[i].Snippet;
                        string f = raw.Replace("<span class=\"searchmatch\">", "");
                        f = f.Replace("</span>", "");
                        Program.WriteLn(f, true, ConsoleColor.Magenta);
                    }
                    Program.WriteLn("::End:Results::", true, ConsoleColor.Yellow);
                }
                else { throw new Exception("Unknown Command"); }
                return result;
            }
            public static string SetMax(List<string> args)
            {
                if (LOGIN.loged)
                {
                    max = Convert.ToInt32(Program.GetArgs(args, 2));
                    Program.WriteLn($"Max Set to : {max}", true, ConsoleColor.Yellow);
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
        }
        public static class LOGIN
        {
            public static bool loged = false;
            public static string Login(List<string> args)
            {
                Console.Clear();
                if (Program.GetArgs(args, 1, -1).Trim() == "4628")
                {
                    loged = true;
                }
                if (Program.GetArgs(args, 1).Trim().ToLower() == "lo")
                {
                    loged = false;
                }
                if (loged)
                    Program.WriteLn($"Logged : {loged}", true, ConsoleColor.Green);
                else
                    Program.WriteLn($"Logged : {loged}", true, ConsoleColor.Red);
                return "";
            }
        }
    }
}
