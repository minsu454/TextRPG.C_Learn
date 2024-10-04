using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{   
    public class Stage
    {
        public int gold;
        public int mobCount;

        public Stage(int gold, int mobCount)
        {
            this.gold = gold;
            this.mobCount = mobCount;
        }
    }
}
