using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public interface IWeapon
    {
        public string Name { get; }  // 무기 이름
        public string Type { get; } // 종류
        public string AbleJob { get; } // 착용 가능 직업
        public int WeaponAttack { get; } // 공격력
        public int WeaponPrice { get; } // 가격
    }
}
