using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography;

namespace TextRPG
{

    public static class GameManager
    {
        public static bool isRun = true;

        public readonly static SceneManager Scene = new SceneManager();         //씬 매니저
        public readonly static SaveManager Save = new SaveManager();            //저장 매니저
        public readonly static QuestManager Quest = new QuestManager();         //퀘스트 매니저
        public readonly static EventManager Event = new EventManager();         //이벤트 매니저

        public static Player player = new Player();
        
        /// <summary>
        /// 생성 함수
        /// </summary>
        public static void Init()
        {
            isRun = true;
            Scene.Init();
            Quest.Init();
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
