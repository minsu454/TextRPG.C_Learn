namespace TextRPG
{
    public class RestQuest : BaseQuest
    {
        public override QuestNameType QuestNameType => QuestNameType.Rest;

        public override string Name => "휴식";
        public override string Comment => "던전을 많이 돌아 지친 우리들에게 휴식은 필수이다.\n휴식하기 기능을 이용해보자";
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
