using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography;
using TextRPG.Interface;

namespace TextRPG
{

    public static class GameManager
    {
        public static bool isRun = true;

        public readonly static SceneManager Scene = new SceneManager();         //씬 매니저
        public readonly static SaveManager Save = new SaveManager();            //저장 매니저
        public readonly static QuestManager Quest = new QuestManager();         //퀘스트 매니저
        public readonly static EventManager Event = new EventManager();         //이벤트 매니저
        public readonly static StageInfo Stage = new StageInfo();

        public static Player player;
        public static Weapon weapon;
        public static Armor armor;
        public static List<Weapon> weapondb;
        public static List<Armor> armordb;
                
        /// <summary>
        /// 생성 함수
        /// </summary>
        public static void Init()
        {
            isRun = true;
            Scene.Init();
            Quest.Init();
        }

        public static void ItemInit() 
        {
            weapondb = new List<Weapon>();
            weapondb.Add(new Weapon("강철검", "검", "전사", 10, 100));
            weapondb.Add(new Weapon("나무스태프", "스태프", "마법사", 40, 130));
            weapondb.Add(new Weapon("목궁", "활", "궁수", 30, 120));
            weapondb.Add(new Weapon("수리검", "표창", "도적", 20, 110));

            armordb = new List<Armor>();
            armordb.Add(new Armor("철갑옷", "철갑옷", "전사", 15, 120));
            armordb.Add(new Armor("로브", "가운", "마법사", 20, 130));
            armordb.Add(new Armor("천옷", "천옷", "궁수", 10, 110));
            armordb.Add(new Armor("철갑옷", "철갑옷", "전사", 25, 140));
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
