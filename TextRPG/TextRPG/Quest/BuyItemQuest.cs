namespace TextRPG
{
    public class BuyItemQuest : BaseQuest
    {
        public override QuestType QuestType => QuestType.BuyItem;

        public override string Name => "무기구매";
        public override string Comment => "하나만 사보자";
        public override string Reward => "1000 G";

        public override void Init()
        {
            GameManager.Event.Subscribe(GameEventType.BuyItem, OnBuyItem);
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.BuyItem, OnBuyItem);
        }

        private void OnBuyItem(object args)
        {
            BuyItemEventArgs buyItem = args as BuyItemEventArgs;

            if (buyItem!.Name == "무기")
            {
                State = QuestStateType.Completed;
            }
        }

        public override void GiveReward()
        {

        }
    }
}
