namespace TextRPG
{



    //몬스터 클래스

    public class Monster : Character
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public bool IsDead => Health <= 0;
        
        // 몬스터가 데미지를 받았을 경우에 나오는 결과

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
             

    }
}
    
    

