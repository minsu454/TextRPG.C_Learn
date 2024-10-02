namespace TextRPG
{
    public class EarthShatter : ISkill
    {
        public string Name => "대지 가르기";
        public string Comment => "무기를 바닥에 강하게 내리쳐, 전방의 모든 적에게 충격파를 발사합니다.";
        public TargetType TargetType => TargetType.All;

        public int Mana => 30;

        public int Use(int playerAttack)
        {
            return playerAttack;
        }
    }
}
