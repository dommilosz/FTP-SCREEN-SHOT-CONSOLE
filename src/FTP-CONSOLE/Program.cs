using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_CONSOLE
{
    class Program
    {
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
            Console.ForegroundColor = ConsoleColor.White;
            string codes = "0123456789abcdef";
            for (int i = 0; i < txt.Length; i++)
            {
                if (txt.Length - 1 > i + 1)
                {
                    if (txt[i] == '&' && codes.Contains(txt[i + 1]))
                    {
                        if (i - 1 >= 0)
                        {
                            if (txt[i - 1] == @"\"[0])
                            {
                                Console.Write(txt[i]);
                            }
                            else { Console.ForegroundColor = DecodeCode(txt[i + 1]); txt = txt.Remove(i, 1); }
                        }
                        else { Console.ForegroundColor = DecodeCode(txt[i + 1]); txt = txt.Remove(i, 1); }


                    }
                    else if (txt[i] != @"\"[0]) Console.Write(txt[i]);
                }
                else if (txt[i] != @"\"[0]) Console.Write(txt[i]);
            }
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static ConsoleColor DecodeCode(char code)
        {
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
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    WriteTxt("/");
                    Console.SetCursorPosition(1, Console.CursorTop - 1);
                    List<string> argsl = Console.ReadLine().Split(' ').ToList();
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
                        default: throw new Exception("Unknown Command");
                    }

                }
                catch (Exception ex) { WriteTxt($"&4{ex.Message}"); }
            }
        }
    }
}
