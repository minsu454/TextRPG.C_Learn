using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public interface IWeapon
    {
        //무기 이름
        //종류
        //착용 가능 직업
        //공격력
        //가격

        string Name { get; }
        string Type { get; }
        string AbleJob { get; }
        int WeaponAttack { get; }
        int WeaponPrice { get; }
    }
}
