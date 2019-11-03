using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPScreenShot
{
    public class ResultsList
    {
        public List<string> Titles { get; private set; }
        public List<string> Snippets { get; private set; }

        public ResultsList(List<WikipediaNet.Objects.Search> searches)
        {
            SetReference();
            for (int i = 0; i < searches.Count; i++)
            {
                Titles.Add(searches[i].Title);
                Snippets.Add(searches[i].Snippet);
            }
        }
        public ResultsList(List<string> ts, List<string> ss)
        {
            SetReference();
            Titles = ts;
            Snippets = ss;
        }
        public static ResultsList FromException(Exception ex)
        {
            List<string> t = new List<string>();
            t.Add(ex.Message);
            List<string> s = new List<string>();
            s.Add(ex.ToString());
            TOConsole(new ResultsList(t, s),true);
            return new ResultsList(t, s);
        }
        public static ResultsList FromString(string title, string snippet)
        {
            List<string> t = new List<string>();
            t.Add(title);
            List<string> s = new List<string>();
            s.Add(snippet);
            TOConsole(new ResultsList(t, s));
            return new ResultsList(t, s);
        }
        public static void TOConsole(ResultsList rl,bool ex = false)
        {
            DevConsole d = DevConsole.ShowGetConsole();
            for (int i = 0; i < rl.Snippets.Count; i++)
            {
                if(!ex)
                    d.SendCmd("echo " + rl.Snippets[i]);
                if (ex)
                    d.SendCmd("echocl red " + rl.Snippets[i]);
            }
        }
        void SetReference()
        {
            Titles = new List<string>();
            Snippets = new List<string>();
            Titles.Clear();
            Snippets.Clear();
        }
    }
}
