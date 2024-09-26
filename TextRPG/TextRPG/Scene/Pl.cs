using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Pl
    {
        public string name;
        public int hp;
        public int mp;

        public List<int> list = new List<int>();
        public Stack<string> stack = new Stack<string>();
        public Dictionary<int, string> dic = new Dictionary<int, string>();

        public Pl(string name, int hp, int mp)
        {
            this.name = name;
            this.hp = hp;
            this.mp = mp;

            list.Add(3);
            list.Add(2);
            list.Add(5);

            stack.Push("q");
            stack.Push("w");
            stack.Push("e");

            dic.Add(1, "r");
            dic.Add(2, "t");
            dic.Add(3, "y");
        }

        public void Add()
        {
            name = "!";
        }
    }

    

}
