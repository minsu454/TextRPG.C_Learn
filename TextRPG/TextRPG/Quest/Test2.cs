namespace TextRPG
{
    public class Test2 : BaseQuest
    {
        public override void Init()
        {
            EventType = GameEventType.KillEnemy;

            name = "고블린";
            comment = "하나만 잡아보자";
            pay = "10000 G";
        }

        public override EventListener? listener()
        {
            return OnKillEnemy;
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.KillEnemy, OnKillEnemy);
        }

        private void OnKillEnemy(object args)
        {
            BuyItemEventArgs? buyItem = args as BuyItemEventArgs;

            if (buyItem!.Name == "무기")
            {
                state = QuestStateType.Completed;
            }
        }
    }
}
