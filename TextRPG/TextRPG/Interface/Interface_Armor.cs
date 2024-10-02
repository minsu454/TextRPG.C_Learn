using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Interface
{
    public interface IArmor
    {
        public string Name { get; } // 방어구 이름
        public string Type { get; } // 종류
        public string AbleJob { get; } // 착용 가능 직업
        public int ArmorDefence { get; } // 방어력
        public int ArmorPrice { get; } // 가격
    }
}
