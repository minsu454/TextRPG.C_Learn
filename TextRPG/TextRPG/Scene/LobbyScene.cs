namespace TextRPG
{
    public class LobbyScene : BaseScene, IMainScene
    {
        private int shiftCount;

        public override void Init()
        {
            shiftCount = 2;
        }

        public override void Load()
        {
            Print.ColorPrintScreen(ConsoleColor.Green, $"이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            int input = Input.Selection(1, "상태 보기", "인벤토리", "상점", "퀘스트", "던전입장", "휴식하기", "도박하기", "저장하기");

            GameManager.Scene.OpenScene((SceneType)(input + shiftCount));
        }

    }
}

