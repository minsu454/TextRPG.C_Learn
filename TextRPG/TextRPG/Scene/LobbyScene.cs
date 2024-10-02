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
            Console.Write(lobbyFormat);
            int input = Input.Selection(1, "상태 보기", "인벤토리", "상점", "퀘스트", "던전입장", "휴식하기", "도박하기", "저장하기");

            GameManager.Scene.OpenScene((SceneType)(input + shiftCount));
        }

    }
}

