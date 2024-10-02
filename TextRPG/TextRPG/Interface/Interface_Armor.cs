using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Interface
{
    public interface IArmor
    {
        string Name { get; } // 방어구 이름
        string Type { get; } // 종류
        string AbleJob { get; } // 착용 가능 직업
        int ArmorDefence { get; } // 방어력
        int ArmorPrice { get; } // 가격
    }
}
