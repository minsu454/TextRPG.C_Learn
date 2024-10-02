using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    //캐릭터 인터페이스

    public interface Character
    {
        int Level { get; set; }
        string Name { get; set; }
        int Health { get; set; }
        int Attack { get; set; }
        int Defence { get; set; }
        int Exp { get; set; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }
        
}
