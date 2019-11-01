using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP_CONSOLE
{
    class Program
    {
        public static string GetArgs(List<string> args, int fromindex, int toindex = -2)
        {
            string rn = "";
            List<string> arg = args;
            if (toindex == -1) toindex = arg.Count - 1;
            if (toindex == -2) toindex = fromindex;
            for (int i = fromindex; i <= toindex; i++)
            {
                rn += arg[i] + " ";
            }
            return rn;
        }
        public static void WriteLn(string txt, bool line = true, ConsoleColor cl = ConsoleColor.White)
        {
            Console.ForegroundColor = cl;
            if (line)
            {
                Console.WriteLine(txt);
            }
            else { Console.Write(txt); }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    List<string> argsl = Console.ReadLine().Split(' ').ToList();
                    switch (GetArgs(argsl, 0).ToLower().Trim())
                    {
                        case "wikisearch":
                        case "ws": Commands.WIKISEARCH.Run(argsl); break;
                        case "clear":
                        case "cs": Commands.CLEAR.Run(argsl); break;
                        case "login":
                        case "ln": Commands.LOGIN.Login(argsl); break;
                        default:throw new Exception("Unknown Command");
                    }

                }
                catch (Exception ex) { WriteLn(ex.Message, true, ConsoleColor.Red); }
            }
        }
    }
}
