namespace TextRPG
{
    public class FuryStrike : ISkill
    {
        public string Name => "분노의 일격";
        public string Comment => "강력한 근접 공격으로 적에게 큰 피해를 입힙니다.";
        public TargetType TargetType => TargetType.Single;

        public int Mana => 10;

        public int Use(int playerAttack)
        {
            return playerAttack + 30;
        }
    }
}
