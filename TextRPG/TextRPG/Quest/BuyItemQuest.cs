namespace TextRPG
{
    public class BuyItemQuest : BaseQuest
    {
        public override QuestNameType QuestNameType => QuestNameType.BuyItem;

        public override string Name => "전설의 무기 찾기";
        public override string Comment =>
@"오래전, 고대의 전사들이 사용하던 전설의 무기가 세상에 모습을 드러냈다는 소문이 떠돌고 있습니다.
이 무기는 상상을 초월하는 힘을 지니고 있어, 그 주인을 새로운 시대의 영웅으로 만들 수 있다고 합니다.
수많은 모험가들이 이 무기를 찾아 떠났지만, 아무도 돌아오지 않았습니다. 이제 당신이 그 운명을 바꿀 차례입니다.
위험한 던전과 강력한 적들이 당신을 기다리고 있습니다. 이 전설의 무기를 손에 넣을 수 있는 자는 오직 하나, 당신일까요?";

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
