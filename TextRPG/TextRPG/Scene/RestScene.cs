namespace TextRPG
{
    public class RestScene : BaseScene
    {

        public override void Load()
        {
            Console.WriteLine($"현재 체력: {GameManager.player!.playerCurHealth}");  //플레이어의 현재 체력
            Console.WriteLine("휴식하시겠습니까?");

            ChooseChoice();

            GameManager.Scene.CloseScene();
        }

        public void ChooseChoice()
        {
            int input = Input.Selection(1, "예.", "아니오.");

            if (input == 1)
            {
                GameManager.player!.playerCurHealth = GameManager.player.playerMaxHealth;
                GameManager.Event.Dispatch(GameEventType.Rest, new RestEventArgs());
            }
        }
    }

}