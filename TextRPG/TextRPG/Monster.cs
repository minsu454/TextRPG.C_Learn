namespace TextRPG
{ 
    //캐릭터 인터페이스

        public interface Charater
    {
        int Level { get; }
        string Name { get; }
        int Health { get; set; }
        int Attack { get; }
        bool IsDead {  get; }
        void TakeDamage(int damage);                
    }
    
    
    
    //몬스터 클래스

    public class Monster : Charater
    {
       public int Level { get; }
       public string Name { get; }
       public int Health { get; set;  }
       public int Attack { get; }
       public bool IsDead => Health <= 0;
        public Monster(int level, string name, int health, int attack)
        {
            Level = level;
            Name = name;
            Health = health;
            Attack = attack;
        }
        int[] level = { 1, 2, 3, 4 };
        int[] health = { 50, 70, 100, 150 };
        int[] attack = { 10, 20, 30, 40 };

        public (int Health, int Attack) GetStatsByLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return (50, 10);
                case 2:
                    return (70, 20);
                case 3:
                    return (100, 30);
                case 4:
                    return (150, 40);
                default:
                    return (0, 0); // 유효하지 않은 레벨의 경우 기본값
            }
        }

        public void TakeDamage(int damage) 
        {
            if (IsDead)
            {
                Console.WriteLine($"{Name}이(가) 죽었습니다.");
            }
            else
            {
                Health -= damage;
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");
            }
        }
        //고블린 클래스

        public class Goblin : Monster
        {
            public Goblin(int level, int attack, string name) : base(level,name, 50, attack) { } // 체력 50
        }




    }
}
