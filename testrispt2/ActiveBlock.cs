using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testrispt2
{
    class ActiveBlock
    {
        public int x = 0;
        public int y = 0;
        public Boolean active = false;


        public void Init()
        {
            Random rnd = new Random();
            x = 21;
            y = rnd.Next(0, 10);
            if(Display.Rows[x][y] != "[0]")
            {
                Display.Rows[x][y] = "[O]";
                active = true;
            }
        }
    }
}


