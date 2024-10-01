namespace TextRPG
{
    public class BaseStageClearQuest : BaseQuest
    {
        public override QuestType QuestType => QuestType.StageClear;

        public override string Name => "기본 다지기";
        public override string Comment => "던전에 있는";
        public override string Reward => "1000 G";

        private int maxCount = 5;

        public override void Init()
        {
            GameManager.Event.Subscribe(GameEventType.StageClear, OnStageClear);
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.StageClear, OnStageClear);
        }

        private void OnStageClear(object args)
        {
            //if (buyItem!.Name == "무기")
            //{
            //    State = QuestStateType.Completed;
            //}
        }
    }
}
