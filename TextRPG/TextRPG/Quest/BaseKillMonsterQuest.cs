namespace TextRPG
{
    public class BaseKillMonsterQuest : BaseQuest
    {
        public override QuestType QuestType => QuestType.KillGoblin;

        protected virtual string MonsterName { get; }
        protected virtual int CurCount { get; private set; } = 0;
        protected virtual int MaxCount { get; }

        public override void Init()
        {
            GameManager.Event.Subscribe(GameEventType.KillMonster, OnKillEnemy);
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.KillMonster, OnKillEnemy);
        }

        private void OnKillEnemy(object args)
        {
            BuyItemEventArgs buyItem = args as BuyItemEventArgs;

            if (MonsterName != buyItem.Name)
            {
                return;
            }

            CurCount += buyItem.Count;

            if (CurCount >= MaxCount)
            {
                State = QuestStateType.Completed;
                
                //보상주기
            }
        }
    }
}
