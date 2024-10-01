namespace TextRPG
{
    public class Test3 : BaseQuest
    {
        public override string Name => "휴식";
        public override string Comment => "3번 해보자";
        public override string Reward => "100 G";

        public int count = 0;

        public override void Init()
        {
            GameManager.Event.Subscribe(GameEventType.Rest, OnRest);
            GameManager.Event.Subscribe(GameEventType.KillEnemy, OnKillEnemy);
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.Rest, OnRest);
            GameManager.Event.Unsubscribe(GameEventType.KillEnemy, OnKillEnemy);
        }

        private void OnRest(object args)
        {
            count++;

            if (count == 3)
            {
                State = QuestStateType.Completed;
            }
        }

        private void OnKillEnemy(object args)
        {
            count++;

            if (count == 3)
            {
                State = QuestStateType.Completed;
            }
        }
    }
}
