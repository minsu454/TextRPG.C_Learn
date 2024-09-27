
namespace TextRPG
{
    public class BuyItemEventArgs
    {
        public string? Name { get; set; }
        public int Count { get; set; }
    }

    public class Test1 : BaseQuest
    {

        public override void Init()
        {
            type = QuestType.PlayerStat;
            name = "무기구매";
            comment = "하나만 사보자";
            pay = "1000 G";

            GameManager.Event.Subscribe(GameEventType.BuyItem, OnBuyItem);
        }

        public override void Release()
        {
            GameManager.Event.Unsubscribe(GameEventType.BuyItem, OnBuyItem);
        }

        private void OnBuyItem(object args)
        {
            BuyItemEventArgs? ar = args as BuyItemEventArgs;

            if (ar.Name == "무기")
            {
                state = QuestState.Completed;
            }
        }
    }
}
