namespace TextRPG
{
    public class KillGoblinQuest : BaseKillMonsterQuest
    {
        public override string Name => "고블린";
        public override string Comment => "하나만 잡아보자";
        public override string Reward => "10 G";

        protected override string MonsterName => "Goblin";
        protected override int MaxCount => 1;
    }
}
