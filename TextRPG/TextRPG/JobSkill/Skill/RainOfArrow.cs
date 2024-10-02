namespace TextRPG
{
    public class RainOfArrow : ISkill
    {
        public string Name => "화살비";
        public string Comment => "하늘로 여러 개의 화살을 쏘아 올려 넓은 지역에 화살비를 내립니다.";
        public TargetType TargetType => TargetType.All;

        public int Mana => 40;

        public int Use(int playerAttack)
        {
            return playerAttack;
        }
    }
}
