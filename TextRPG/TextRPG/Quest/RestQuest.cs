namespace TextRPG
{
    public class RestQuest : BaseQuest
    {
        public override string Name => "휴식";
        public override string Comment => "10번 해보자";
        public override string Reward => "100 G";

        public int count = 0;

        public override void Init()
        {
            GameManager.Event.Subscribe(GameEventType.Rest, OnRest);
            GameManager.Event.Subscribe(GameEventType.KillMonster, OnKillEnemy);
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.Rest, OnRest);
            GameManager.Event.Unsubscribe(GameEventType.KillMonster, OnKillEnemy);
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

            if (count == 10)
            {
                State = QuestStateType.Completed;

                //보상주기
            }
        }
    }
}
