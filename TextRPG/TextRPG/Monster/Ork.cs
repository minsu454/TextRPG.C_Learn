using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    //오크 클래스

    public class Ork : Monster
    {
        public Ork(int level, string name)
        {
            Level = level;
            Name = name;
            (int Health, int Attack, int Defence) info = GetStatsByLevel(level);
        }
        int[] level = { 1, 2, 3, 4 };
        int[] health = { 60, 80, 110, 160 };
        int[] attack = { 15, 25, 35, 45 };
        int[] defence = { 10, 15, 20, 25 };

        private (int Health, int Attack, int Defence) GetStatsByLevel(int level)
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
