namespace TextRPG
{
    public static class GameManager
    {
        public static bool isRun = true;

        public readonly static SceneManager Scene = new SceneManager();         //씬 매니저

        /// <summary>
        /// 생성 함수
        /// </summary>
        public static void Init()
        {
            isRun = true;
            Scene.Init();
        }

        /// <summary>
        /// 업데이트 함수
        /// </summary>
        public static void Update()
        {
            Scene.LoadScene();

            Console.Clear();
            Thread.Sleep(100);
        }

        /// <summary>
        /// 삭제 함수
        /// </summary>
        public static void Destroy()
        {

        }
    }
}
