using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public interface IWeapon
    {
        string Name { get; }  // 무기 이름
        string Type { get; } // 종류
        string AbleJob { get; } // 착용 가능 직업
        int WeaponAttack { get; } // 공격력
        int WeaponPrice { get; } // 가격
    }
}
