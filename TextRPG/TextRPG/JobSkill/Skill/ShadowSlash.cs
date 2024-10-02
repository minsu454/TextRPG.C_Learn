namespace TextRPG
{
    public class ShadowSlash : ISkill
    {
        public string Name => "그림자 베기";
        public string Comment => "빠르게 적의 뒤로 이동하여 공격을 가한 뒤, 다시 그림자 속으로 사라집니다.";
        public TargetType TargetType => TargetType.Single;

        public int Mp => 30;

        public int Use(int playerAttack)
        {
            return playerAttack + 40;
        }
    }
}
