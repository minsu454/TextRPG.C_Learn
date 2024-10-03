namespace TextRPG
{
    public class RestScene : BaseScene
    {
        public int restGold = 300;
        private Player player;

        public override void Load()
        {
            player = GameManager.player;

            Print.ColorPrintScreen(ConsoleColor.DarkRed, "현재 체력", false);
            Console.Write($": {player.playerCurHealth}/{player.playerMaxHealth}     ");

            Print.ColorPrintScreen(ConsoleColor.DarkBlue, "현재 마나", false);
            Console.WriteLine($": {player.playerCurMp}/{player.playerMaxMp}");

            Print.ColorPrintScreen(ConsoleColor.Yellow, "현재 골드", false);
            Console.WriteLine($": {player.playerGold} G\n");
            Console.WriteLine($"여관에서 휴식하시겠습니까? 가격 : - {restGold} G");

            ChooseChoice();

            GameManager.Scene.CloseScene();
        }

        public void ChooseChoice()
        {
            int input = Input.Selection(1, "예.", "아니오.");
            Console.WriteLine();

            if (input == 1)
            {
                if (0 > player.playerGold - restGold)
                {
                    Print.PrintScreenAndSleep("돈이 부족해서 여관에서 쫒겨났다.");
                    return;
                }

                player.playerGold -= restGold;
                player.playerCurHealth = player.playerMaxHealth;
                player.playerCurMp = player.playerMaxMp;
                GameManager.Event.Dispatch(GameEventType.Rest, new RestEventArgs());
                Print.PrintScreenAndSleep("몸이 완전히 회복되었다.");
            }
        }
    }
}