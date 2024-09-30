namespace TextRPG
{
        
    public class IronSword : IWeapon
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int WeaponAttack { get; set; }
        public int WeaponPrice { get; set; }

        public IronSword(string name, string sword, string warrior)
        {
            Name = name;
            Type = sword;
            AbleJob = warrior;
            WeaponAttack = 10; // �⺻ ���ݷ�
            WeaponPrice = 100; // �⺻ ����
        }
    }

    public class WoodStaff : IWeapon
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int WeaponAttack { get; set; }
        public int WeaponPrice { get; set; }

        public WoodStaff(string name, string staff, string magician)
        {
            Name = name;
            Type = staff;
            AbleJob = magician;
            WeaponAttack = 40; // �⺻ ���ݷ�
            WeaponPrice = 130; // �⺻ ����
        }
    }

    public class WoodBow : IWeapon
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int WeaponAttack { get; set; }
        public int WeaponPrice { get; set; }

        public WoodBow(string name, string bow, string archer)
        {
            Name = name;
            Type = bow;
            AbleJob = archer;
            WeaponAttack = 30; // �⺻ ���ݷ�
            WeaponPrice = 120; // �⺻ ����
        }
    }

    public class Shuriken : IWeapon
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int WeaponAttack { get; set; }
        public int WeaponPrice { get; set; }

        public Shuriken(string name, string dart, string thief)
        {
            Name = name;
            Type = dart;
            AbleJob = thief;
            WeaponAttack = 20; // �⺻ ���ݷ�
            WeaponPrice = 110; // �⺻ ����
        }
    }
} 
   