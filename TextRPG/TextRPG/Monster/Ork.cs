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
            
            (int Health, int Attack, int Defence, int exp) info = GetStatsByLevel(level);

            Health = info.Health;
            Attack = info.Attack;
            Defence = info.Defence;
            Exp = info.exp;
        }

        //int[] level = { 1, 2, 3, 4 };
        //int[] health = { 60, 80, 110, 160 };
        //int[] attack = { 15, 25, 35, 45 };
        //int[] defence = { 10, 15, 20, 25 };
        //int[] expArr = { 3, 4, 5, 6 };

        private (int Health, int Attack, int Defence, int exp) GetStatsByLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return (60, 25, 5, 4);
                case 2:
                    return (90, 35, 10, 6);
                case 3:
                    return (160, 45, 15, 8);
                case 4:
                    return (190, 55, 20, 10);
                default:
                    return (0, 0, 0, 0); // 유효하지 않은 레벨의 경우 기본값
            }
        }


    }
}
