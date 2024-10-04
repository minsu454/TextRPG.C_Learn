namespace TextRPG
{
    public class IceSpear: ISkill
    {
        public string Name => "얼음 창";
        public string Comment => "날카로운 얼음 창을 만들어 모든 적에게 던져 즉각적인 피해를 입힙니다.";
        public TargetType TargetType => TargetType.All;

        public int Mp => 30;

        public int Use(int playerAttack)
        {
            return playerAttack + 10;
        }
    }
}
