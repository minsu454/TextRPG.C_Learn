namespace TextRPG
{
    public class RestScene : BaseScene
    {
        public int restGold = 300;

        public override void Load()
        {
            Console.WriteLine($"현재 체력: {GameManager.player.playerCurHealth} 현재 골드 : {GameManager.player.playerGold}");  //플레이어의 현재 체력
            Console.WriteLine($"여관에서 휴식하시겠습니까? 가격 : - {restGold} G");

            ChooseChoice();

            GameManager.Scene.CloseScene();
        }

        public void ChooseChoice()
        {
            int input = Input.Selection(1, "예.", "아니오.");

            if (input == 1)
            {
                if (0 > GameManager.player.playerGold - restGold)
                {
                    Print.PrintScreenAndSleep("돈이 부족해서 여관에서 쫒겨났다.");
                    return;
                }

                GameManager.player.playerGold -= restGold;
                GameManager.player.playerCurHealth = GameManager.player.playerMaxHealth;
                GameManager.player.playerCurMana = GameManager.player.playerMaxMana;
                GameManager.Event.Dispatch(GameEventType.Rest, new RestEventArgs());
            }
        }
    }
}