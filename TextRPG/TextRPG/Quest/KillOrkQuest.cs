namespace TextRPG
{
    public class KillOrkQuest : BaseKillMonsterQuest
    {
        public override string Name => "오크";
        public override string Comment => "열마리 잡아보자";
        public override string Reward => "1000 G";

        protected override string MonsterName => "Goblin";
        protected override int MaxCount => 1;
    }
}
