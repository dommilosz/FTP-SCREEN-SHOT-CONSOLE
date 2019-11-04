using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FTP_CONSOLE
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        public static string GetArgs(List<string> args, int fromindex, int toindex = -2, string add = " ")
        {
            string rn = "";
            List<string> arg = args;
            if (toindex == -1) toindex = arg.Count - 1;
            if (toindex == -2) toindex = fromindex;
            for (int i = fromindex; i <= toindex; i++)
            {
                rn += arg[i] + add;
            }
            return rn.Trim();
        }
        public static void WriteTxt(string txt)
        {
            txt += "    ";
            txt = txt.Replace("0RootScreenShot08/", "");
            Console.ForegroundColor = DecodeCode('f');
            string codes = Commands.CLCODE.codes;
            for (int i = 0; i < txt.Length; i++)
            {
                if (i >= 0 && txt[i] == '@' && txt[i + 1] == '&' && codes.Contains(txt[i + 2]))
                {
                    Console.ForegroundColor = DecodeCode(txt[i + 2], true);
                    txt = txt.Remove(i + 2, 1);
                    txt = txt.Remove(i + 1, 1);
                    txt = txt.Remove(i, 1);
                }
                if (txt.Length - 1 > i + 1 && txt[i] == '&' && codes.Contains(txt[i + 1]))
                {
                    if (i - 1 >= 0 && txt[i - 1] == @"\"[0])
                    {
                        Console.Write(txt[i]);
                    }
                    else { Console.ForegroundColor = DecodeCode(txt[i + 1]); txt = txt.Remove(i+1,1); }
                }
                else { bool tmp = true; if (txt[i] == '@' && txt[i + 1] == '&') tmp = false; if (txt[i] == '&' && codes.Contains(txt[i + 1])) tmp = false; if (txt[i] == @"\"[0]&& txt[i+1] == '&'&&codes.Contains(txt[i+2])) tmp = false; if (tmp) Console.Write(txt[i]); }

            }
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void BackFromGUI()
        {
            Program.ShowWindow(Program.GetConsoleWindow(), Program.SW_SHOW);
        }
        public static ConsoleColor DecodeCode(char code, bool ignoredefcol = false)
        {
            char tmp = Commands.COLOR.color;
            if (!ignoredefcol)
                if (Commands.CLCODE.codes.Contains(tmp)) { code = tmp; }
            ConsoleColor color = ConsoleColor.White;
            switch (code)
            {
                case '0': color = ConsoleColor.Black; break;
                case '1': color = ConsoleColor.DarkBlue; break;
                case '2': color = ConsoleColor.DarkGreen; break;
                case '3': color = ConsoleColor.DarkCyan; break;
                case '4': color = ConsoleColor.DarkRed; break;
                case '5': color = ConsoleColor.DarkMagenta; break;
                case '6': color = ConsoleColor.DarkYellow; break;
                case '7': color = ConsoleColor.Gray; break;
                case '8': color = ConsoleColor.DarkGray; break;
                case '9': color = ConsoleColor.Blue; break;

                case 'a': color = ConsoleColor.Green; break;
                case 'b': color = ConsoleColor.Cyan; break;
                case 'c': color = ConsoleColor.Red; break;
                case 'd': color = ConsoleColor.Magenta; break;
                case 'e': color = ConsoleColor.Yellow; break;
                case 'f': color = ConsoleColor.White; break;
            }
            return color;
        }
        public static void SetTitle(List<string> argsl)
        {
            Console.Title = $"FTP CONSOLE - [";
            foreach (var item in argsl)
            {
                Console.Title += item + " ";
            }
            Console.Title = Console.Title.Trim();
            Console.Title += "]";
        }
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {

                    WriteTxt("@&2/");
                    Console.Title = $"FTP CONSOLE - [IDLE]";
                    Console.SetCursorPosition(1, Console.CursorTop - 1);
                    List<string> argsl = Console.ReadLine().Split(' ').ToList();
                    SetTitle(argsl);
                    if (string.IsNullOrWhiteSpace(GetArgs(argsl, 0).ToLower()))
                    {
                        Main(args);
                        break;
                    }
                    switch (GetArgs(argsl, 0).ToLower())
                    {
                        case "wikisearch":
                        case "ws": Commands.WIKISEARCH.Run(argsl); break;
                        case "clear":
                        case "cs": Commands.CLEAR.Run(argsl); break;
                        case "login":
                        case "ln": Commands.LOGIN.Run(argsl); break;
                        case "credentials":
                        case "cr": Commands.CREDENTIALS.Run(argsl); break;
                        case "write":
                        case "echo": Commands.WRITECMD.Run(argsl); break;
                        case "clcode": Commands.CLCODE.Run(argsl); break;
                        case "screenshot": Commands.SCREENSHOT.Run(argsl); break;
                        case "tree": Commands.TREE.Run(argsl); break;
                        case "gui": Commands.GUI.Run(argsl); break;
                        case "download":
                        case "dl": Commands.DOWNLOAD.Run(argsl); break;
                        case "delete":
                        case "del": Commands.DELETE.Run(argsl); break;
                        case "color": Commands.COLOR.Run(argsl); break;
                        case "exit": Commands.EXIT.Run(argsl); break;
                        default: throw new Exception("Unknown Command");
                    }

                }
                catch (Exception ex) { WriteTxt($"&4{ex.Message}"); }
            }
        }
    }
}
