using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG
{
    public class Armor : IArmor
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int ArmorDefence { get; }
        public int ArmorPrice { get; }

        public Armor(string name, string type, string ablejob, int armorDefence, int armorPrice)
        {
            Name = name; // 아이템 이름
            Type = type; // 아이템 타입
            AbleJob = ablejob; // 착용 가능 직업
            ArmorDefence = armorDefence; // 기본 방어력
            ArmorPrice = armorPrice; // 기본 가격
        }
    }
}
