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
            Name = name; // 아이템 이름
            Type = type; // 아이템 타입
            AbleJob = ablejob; // 착용 가능 직업
            WeaponAttack = weaponAttack; // 기본 공격력
            WeaponPrice = weaponPrice; // 기본 가격
        }
    }
} 
   