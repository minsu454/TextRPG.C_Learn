namespace TextRPG
{
    public class Test2 : BaseQuest
    {
        public override string Name => "고블린";
        public override string Comment => "하나만 잡아보자";
        public override string Reward => "10000 G";

        public override void Init()
        {
            GameManager.Event.Subscribe(GameEventType.KillEnemy, OnKillEnemy);
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.KillEnemy, OnKillEnemy);
        }

        private void OnKillEnemy(object args)
        {
            BuyItemEventArgs buyItem = args as BuyItemEventArgs;

            if (buyItem!.Name == "무기")
            {
                State = QuestStateType.Completed;
            }
        }
    }
}
