using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    //랜덤박스
    public class RandomBox : Monster
    {
        private static Random random = new Random();

        public RandomBox(int level, string name)
        {
            Level = level;
            Name = name;

            // 체력과 방어력은 고정. 
            Health = 100;
            Defence = 10;
            Exp = 15;

            // 공격력만 랜덤으로 설정하기
            Attack = GetRandomAttackPower();
        }

        // 랜덤공격력 0~100 사이 설정
        private int GetRandomAttackPower()
        {
            return random.Next(0, 101); // 랜덤공격력은 0에서 100 사이
        }
    }
}
