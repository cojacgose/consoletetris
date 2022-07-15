using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testrispt2
{
    static public class Display
    {
        static public List<List<string>> Rows = new List<List<string>> { }; //Rows is the X axis, 0 at bottom 21 at top, Columns is the Y axis, 0 at the left, 9 at the right

        static public void Init()
        {
            for (int i = 22; i > 0; i--)
            {
                List<string> Columns = new List<string> { };
                for (int j = 10; j > 0; j--)
                {
                    Columns.Add("[ ]");
                }
                Rows.Add(Columns);
            }
        }

        static public void Refresh()
        {
            Console.Clear();
            string toPrint = "";
            for (int i = Rows.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j<Rows[i].Count;j++)
                {
                    toPrint = toPrint + Rows[i][j];
                }
                toPrint = toPrint + '\n';
            }
            Console.WriteLine(toPrint);
        }
    }
}
