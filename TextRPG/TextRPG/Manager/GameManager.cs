using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography;

namespace TextRPG
{

    public static class GameManager
    {
        static void Main(string[] args)
        {
            Pl p = new Pl("minsu", 100, 10);

            string serialize = JsonConvert.SerializeObject(p);
            Save.Save(p);


            Console.WriteLine(serialize);
        }

        public static bool isRun = true;

        public readonly static SceneManager Scene = new SceneManager();         //씬 매니저
        public readonly static SaveManager Save = new SaveManager();

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
