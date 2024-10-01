namespace TextRPG
{
    public class BaseKillMonsterQuest : BaseQuest
    {
        public override QuestNameType QuestNameType => QuestNameType.KillGoblin;

        protected virtual string MonsterName { get; }

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
            }
        }

        public override void GiveReward() { }
    }
}
