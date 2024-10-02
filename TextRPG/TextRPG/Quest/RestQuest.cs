namespace TextRPG
{
    public class RestQuest : BaseQuest
    {
        public override QuestNameType QuestNameType => QuestNameType.Rest;

        public override string Name => "깊은 휴식";
        public override string Comment =>
@"모험가에게는 싸움만큼 중요한 것이 바로 휴식입니다.
지친 몸과 마음을 회복하지 않으면, 언젠가 큰 위험에 빠질 수 있습니다. 이번에는 전투 대신 휴식에 집중해보세요.
총 10번의 휴식을 통해 충분한 에너지를 회복하고, 앞으로의 여정을 대비하십시오.
이 임무는 한 번만 수행할 수 있는 소중한 기회이니, 충실히 완수하고 새롭게 힘을 얻으세요.";

        public override string Reward => "10 G";

        public override int MaxCount => 10;

        public override void Init()
        {
            GameManager.Event.Subscribe(GameEventType.Rest, OnRest);
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.Rest, OnRest);
        }

        private void OnRest(object args)
        {
            CurCount++;

            if (CurCount >= MaxCount)
            {
                State = QuestStateType.Completed;
            }
        }

        public override void GiveReward()
        {
            GameManager.player.playerGold += 10;
        }
    }
}
