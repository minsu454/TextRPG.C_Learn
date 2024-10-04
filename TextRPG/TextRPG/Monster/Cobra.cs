using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    //독사 클라스, 공격 받으면 독 중첩 데미지 받게

    public class Cobra : Monster
    {
        private int baseAttack = 0; // 기본 공격력
        private int attackMultiplier = 1; // 공격횟수에 비례해서 데미지가 3씩 증가
        private int attacksReceived = 0; // 코브라가 몇 번 공격받는지 추적->0부터 시작.

        public Cobra(int level, string name)
        {
            Level = level;
            Name = name;

            (int Health, int Attack, int Defence, int exp) info = GetStatsByLevel(level);

            Health = info.Health;
            Attack = baseAttack = info.Attack;
            Defence = info.Defence;
            Exp = info.exp;
        }

        // 코브라가 공격 할 때마다 비례 증가 만들기
        public void ReceiveAttack()
        {
            attacksReceived++; // 공격 할 때 마다 ++로 3씩 추가하기
            Attack = baseAttack * attacksReceived; // 기본 공격 + 3 중첩, 첫 번째는 int가 0으로 시작하니 3부터 진행.
        }

        private static (int Health, int Attack, int Defence, int exp) GetStatsByLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return (200, 5, 5, 14); 
                case 2:
                    return (250, 6, 10, 16);
                case 3:
                    return (300, 7, 15, 18);
                case 4:
                    return (350, 8, 20, 20);
                default:
                    return (0, 0, 0, 0); 
            }
        }

    }
}
