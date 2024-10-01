namespace TextRPG
{
    public class KillGoblinQuest : BaseKillMonsterQuest
    {
        public override string Name => "고블린";
        public override string Comment => "5마리 잡아보자";
        public override string Reward => "100 G";

        protected override string MonsterName => "Goblin";
        public override int MaxCount => 5;

        public override void GiveReward()
        {
            GameManager.player.playerGold += 100;
            State = QuestStateType.None;
        }
    }
}
