namespace TextRPG
{
    public class StageClearQuest : BaseQuest
    {
        public override string Name => "던전 탐험";
        public override string Comment => "다양한 몬스터들을 만나보자";
        public override string Reward => "1000 G";

        protected virtual int MaxCount { get; }

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
            if (GameManager.player.StageNum == MaxCount)
            {
                State = QuestStateType.Completed;
            }
        }

        public override void GiveReward()
        {

        }
    }
}
