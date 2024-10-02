namespace TextRPG
{
    public class KillGoblinQuest : BaseKillMonsterQuest
    {
        public override string Name => "고블린 소탕";
        public override string Comment =>
@"근처 숲 속에서 고블린들이 마을을 위협하고 있습니다.
이들은 잦은 습격으로 마을 사람들의 생활을 불안하게 만들고 있으며, 계속해서 그 수가 늘어나고 있습니다.
마을을 안전하게 지키기 위해 고블린 5마리를 처치해주십시오.
이 일은 끊임없이 벌어지는 위협이기에, 필요할 때마다 다시 요청될 수 있습니다. 마을의 평화를 지키는 당신의 노력이 절실합니다.";

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
