using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Interface
{
    public interface IArmor
    {
        //방어구 이름
        //종류
        //착용 가능 직업
        //방어력
        //가격

        string Name { get; }
        string Type { get; }
        string AbleJob { get; }
        int ArmorDefence { get; }
        int ArmorPrice { get; }
    }
}
