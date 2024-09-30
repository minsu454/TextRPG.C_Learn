using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interface;

namespace TextRPG
{
    public class IronArmor : IArmor
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int ArmorDefence { get; }
        public int ArmorPrice { get; }

        public IronArmor(string name, string ironArmor, string warrior)
        {
            Name = name;
            Type = ironArmor;
            AbleJob = warrior;
            ArmorDefence = 15;
            ArmorPrice = 120;
        }
    }
    public class Robe : IArmor
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int ArmorDefence { get; }
        public int ArmorPrice { get; }

        public Robe(string name, string gown, string magician)
        {
            Name = name;
            Type = gown;
            AbleJob = magician;
            ArmorDefence = 20;
            ArmorPrice = 130;
        }
    }

    public class Cloth : IArmor
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int ArmorDefence { get; }
        public int ArmorPrice { get; }

        public Cloth(string name, string cloth, string archer)
        {
            Name = name;
            Type = cloth;
            AbleJob = archer;
            ArmorDefence = 10;
            ArmorPrice = 110;
        }
    }

    public class Suit : IArmor
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int ArmorDefence { get; }
        public int ArmorPrice { get; }

        public Suit(string name, string uniform, string thief)
        {
            Name = name;
            Type = uniform;
            AbleJob = thief;
            ArmorDefence = 25;
            ArmorPrice = 140;
        }
    }
}
