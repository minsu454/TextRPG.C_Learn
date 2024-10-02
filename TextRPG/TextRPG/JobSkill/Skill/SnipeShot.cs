namespace TextRPG
{
    public class SnipeShot : ISkill
    {
        public string Name => "저격 사격";
        public string Comment => "멀리 있는 적을 정확하게 겨냥해 강력한 일격을 가합니다.";
        public TargetType TargetType => TargetType.Single;

        public int Mana => 20;

        public int Use(int playerAttack)
        {
            return playerAttack + 40;
        }
    }
}
