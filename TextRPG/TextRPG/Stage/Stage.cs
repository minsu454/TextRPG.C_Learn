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
        public int mobMinCount;
        public int mobMaxCount;

        public Stage(int gold, int mobMinCount, int mobMaxCount)
        {
            this.gold = gold;
            this.mobMinCount = mobMinCount;
            this.mobMaxCount = mobMaxCount;
        }
    }
}
