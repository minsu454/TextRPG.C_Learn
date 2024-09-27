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
        bool IsDead { get; }
        void TakeDamage(int damage);
    }



    //몬스터 클래스

    public class Monster : Character
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public bool IsDead => Health <= 0;
        

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
         public Goblin(int level, string name, int health, int attack, int defence)
         {
            Level = level;
            Name = name;
            Health = health;
            Attack = attack;
            Defence = defence;
         }
            int[] level = { 1, 2, 3, 4 };
            int[] health = { 50, 70, 100, 150 };
            int[] attack = { 10, 20, 30, 40 };
            int[] defence = { 5, 10, 15, 20 };

           public (int Health, int Attack, int Defence) GetStatsByLevel(int level)
           {
            switch (level)
            {
                case 1:
                    return (50, 10, 5);
                case 2:
                    return (70, 20, 10);
                case 3:
                    return (100, 30, 15);
                case 4:
                    return (150, 40, 20);
                default:
                    return (0, 0, 0); // 유효하지 않은 레벨의 경우 기본값
            }
           }        
         
            
        }

        //오크 클래스

        public class Ork : Monster
        {
            public Ork(int level, string name, int health, int attack, int defence)
            {
                Level = level;
                Name = name;
                Health = health;
                Attack = attack;
                Defence = defence;
            }
            int[] level = { 1, 2, 3, 4 };
            int[] health = { 60, 80, 110, 160 };
            int[] attack = { 15, 25, 35, 45 };
            int[] defence = { 10, 15, 20, 25 };

            public (int Health, int Attack, int Defence) GetStatsByLevel(int level)
            {
                switch (level)
                {
                    case 1:
                        return (60, 15, 10);
                    case 2:
                        return (80, 25, 15);
                    case 3:
                        return (110, 35, 20);
                    case 4:
                        return (160, 45, 25);
                    default:
                        return (0, 0, 0); // 유효하지 않은 레벨의 경우 기본값
                }
            }

            
        }


    }
}
    
    

