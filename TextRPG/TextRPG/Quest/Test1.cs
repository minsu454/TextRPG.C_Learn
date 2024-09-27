namespace TextRPG
{
    public class Test1 : BaseQuest
    {
        public override void Init()
        {
            EventType = GameEventType.BuyItem;

            name = "무기구매";
            comment = "하나만 사보자";
            pay = "1000 G";
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.BuyItem, OnBuyItem);
        }

        public override EventListener? listener()
        {
            return OnBuyItem;
        }

        private void OnBuyItem(object args)
        {
            BuyItemEventArgs? buyItem = args as BuyItemEventArgs;

            if (buyItem!.Name == "무기")
            {
                state = QuestStateType.Completed;
            }
        }
    }
}
