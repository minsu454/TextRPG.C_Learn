namespace TextRPG
{
    public class LobbyScene : BaseScene, IMainScene
    {
        private int shiftCount;

        public override void Init()
        {
            shiftCount = 1;
        }

        public override void Load()
        {
            Print.PrintScreen(lobbyFormat);
            int input = Input.InputKey(7, true);

            GameManager.Scene.OpenScene((SceneType)(1 << input + shiftCount));
        }

        #region PrintFormat
        private string lobbyFormat =
@$"이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

1. 상태 보기
2. 인벤토리
3. 상점
4. 퀘스트
5. 던전입장
6. 휴식하기
7. 저장하기

";
        #endregion
    }
}

