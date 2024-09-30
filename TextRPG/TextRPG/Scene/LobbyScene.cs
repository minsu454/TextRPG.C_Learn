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
            Print.PrintScreen(lobbyFormat);
            int input = Input.Selection(1, "상태 보기", "인벤토리", "상점", "퀘스트", "던전입장", "휴식하기", "저장하기");

            GameManager.Scene.OpenScene((SceneType)(input + shiftCount));
        }

        #region PrintFormat
        private string lobbyFormat =
@$"이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

";
        #endregion
    }
}

