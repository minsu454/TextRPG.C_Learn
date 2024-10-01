using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    //고블린 클래스

    public class Goblin : Monster
    {
        public Goblin(int level, string name)
        {
            Level = level;
            Name = name;
            (int Health, int Attack, int Defence) info = GetStatsByLevel(level);

            Health = info.Health;
            Attack = info.Attack;
            Defence = info.Defence; 
            

        }
        int[] level = { 1, 2, 3, 4 };
        int[] health = { 50, 70, 100, 150 };
        int[] attack = { 10, 20, 30, 40 };
        int[] defence = { 5, 10, 15, 20 };

        private static (int Health, int Attack, int Defence) GetStatsByLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return (50, 10, 5);
                case 2:
                    return (70, 20, 10);
                case 3:
                    return (100, 30, 15);
                case 4:
                    return (150, 40, 20);
                default:
                    return (0, 0, 0); // 유효하지 않은 레벨의 경우 기본값
            }
        }
       

    }

}
