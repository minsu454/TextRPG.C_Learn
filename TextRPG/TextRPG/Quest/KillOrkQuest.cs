namespace TextRPG
{
    public class KillOrkQuest : BaseKillMonsterQuest
    {
        public override string Name => "오크 토벌";
        public override string Comment => 
@"산악 지대에서 오크들이 집결하여 세력을 키우고 있습니다.
이 사악한 존재들은 곧 마을을 습격할 계획을 세우고 있으며, 그들이 행동을 시작하기 전에 제거해야 합니다.
강력한 오크 전사들을 10마리 처치해, 그들의 위협을 근본적으로 차단하십시오.
마을의 생존이 당신의 손에 달려 있습니다.
이번 임무는 쉬운 싸움이 아니지만, 당신의 용맹함으로 이 난관을 돌파해 주시기 바랍니다.";

        public override string Reward => "1000 G";

        protected override string MonsterName => "Ork";
        public override int MaxCount => 10;

        public override void GiveReward()
        {
            GameManager.player.playerGold += 1000;
            State = QuestStateType.None;
        }
    }
}
