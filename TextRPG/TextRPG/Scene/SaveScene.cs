namespace TextRPG
{
    public class SaveScene : BaseScene
    {
        public override void Load()
        {
            Console.WriteLine("지금까지의 내용을 저장하시겠습니까?\n");

            int input = Input.Selection(1, "예.", "아니오.");

            if (input == 1)
            {
                GameManager.Save.Save(GameManager.player);

                Print.PrintScreenAndSleep("\n저장되었습니다.");
            }

            GameManager.Scene.CloseScene();
        }
    }
}
