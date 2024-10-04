namespace TextRPG
{
    public class AssassinBlade : ISkill
    {
        public string Name => "암살자의 칼날";
        public string Comment => "은신 상태에서 적에게 접근해 단검으로 치명적인 일격을 가합니다.";
        public TargetType TargetType => TargetType.Single;
        public int Mp => 50;

        public int Use(int playerAttack)
        {
            return playerAttack + 70;
        }
    }
}
