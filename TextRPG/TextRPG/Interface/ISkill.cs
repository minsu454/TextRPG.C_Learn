namespace TextRPG
{
    public interface ISkill
    {
        public string Name { get; }
        public TargetType TargetType { get; }
        public string Comment { get; }
        public int Mana { get; }

        public int Use(int playerAttack);
    }
}
