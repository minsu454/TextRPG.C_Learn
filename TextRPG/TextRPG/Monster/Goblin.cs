﻿using System;
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
        public Goblin(int level, string name = "Goblin")
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
        //int[] health = { 50, 70, 100, 150 };
        //int[] attack = { 10, 20, 30, 40 };
        //int[] defence = { 5, 10, 15, 20 };

        private (int Health, int Attack, int Defence, int exp) GetStatsByLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return (50, 20, 5, 5);
                case 2:
                    return (80, 30, 10, 7);
                case 3:
                    return (150, 40, 15, 9);
                case 4:
                    return (180, 50, 20, 11);
                default:
                    return (0, 0, 0, 0); // 유효하지 않은 레벨의 경우 기본값
            }
        }
       

    }

}
