namespace TextRPG
{
        
    public class Weapon : IWeapon
    {
        public string Name { get; }
        public string Type { get; }
        public string AbleJob { get; }
        public int WeaponAttack { get; set; }
        public int WeaponPrice { get; set; }

        public Weapon(string name, string type, string ablejob, int weaponAttack, int weaponPrice)
        {
            Name = name; // ������ �̸�
            Type = type; // ������ Ÿ��
            AbleJob = ablejob; // ���� ���� ����
            WeaponAttack = weaponAttack; // �⺻ ���ݷ�
            WeaponPrice = weaponPrice; // �⺻ ����
        }
    }
} 
   