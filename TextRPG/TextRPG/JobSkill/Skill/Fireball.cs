namespace TextRPG
{
    public class Fireball : ISkill
    {
        public string Name => "화염구";
        public string Comment => "불타는 구체를 발사해 모든 적에게 강력한 화염 피해를 입힙니다.";
        public TargetType TargetType => TargetType.All;

        public int Mp => 50;

        public int Use(int playerAttack)
        {
            return playerAttack + 30;
        }
    }
}
