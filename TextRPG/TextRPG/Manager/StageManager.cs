using System.Numerics;

namespace TextRPG
{
    public class StageManager
    {
        private List<Stage> stages = new List<Stage>();

        public List<Monster> monsters = new List<Monster>();
        private const int monsterTypeNum = 4;

        public StageManager()
        {
            stages.Add(new Stage(500, 2));  // 스테이지 1
            stages.Add(new Stage(1000, 3)); // 스테이지 2
            stages.Add(new Stage(1500, 4)); // 스테이지 3
            stages.Add(new Stage(2000, 5)); // 스테이지 4
            stages.Add(new Stage(2500, 6)); // 스테이지 5
        }

        public void Init()
        {
            GameManager.Event.Subscribe(GameEventType.StageClear, StageClear);
        }

        public void Spawn()
        {
            monsters.Clear();

            int[] arr = MobCount();

            Random random = new Random();

            for (int i = 0; i < arr.Length; i++) // arr (return 받아온 배열)로 몹 종류 정하기
            {
                int moblevel = random.Next(1, 5); // 레벨 1~4 랜덤

                if (arr[i] == 0)
                {
                    monsters.Add(new Ork(moblevel));
                }
                else if(arr[i] == 1)
                {
                    monsters.Add(new Goblin(moblevel));
                }
                else if (arr[i] == 2)
                {
                    monsters.Add(new Cobra(moblevel));
                }
                else if (arr[i] == 3)
                {
                    monsters.Add(new RandomBox(moblevel));
                }
            }
        }

        /// <summary>
        /// 스테이지 클리어시 호출하는 함수
        /// </summary>
        private void StageClear(object Args)
        {
            StageClearEventArgs args = Args as StageClearEventArgs;

            Console.Clear();
            Print.ColorPrintScreen(ConsoleColor.Green, "Win!\n");
            Console.WriteLine($"보상으로 {stages[GameManager.player.StageNum - 1].gold} Gold를 획득하였습니다!"); // 클리어 보상

            GameManager.player.playerGold += stages[GameManager.player.StageNum - 1].gold;

            if (GameManager.player.StageNum < stages.Count)
                GameManager.player.StageNum++;

            GameManager.player.GetExp(args.totalExp);

            Print.ColorPrintScreen(ConsoleColor.DarkGreen, "아무키나 누르세요.");
            Console.ReadKey(true);
        }

        private int[] MobCount() // 몹 랜덤
        {
            int nowstage = GameManager.player.StageNum;

            Random random = new Random();

            int mobcount = stages[nowstage - 1].mobCount; // 등장하는 몹의 수

            return MobReturn(mobcount);
        }

        private int[] MobReturn(int mobCount)
        {
            int[] mobArray = new int[mobCount];
            Random random = new Random();

            for (int i = 0; i < mobCount; i++)
            {
                int mobtype = random.Next(0, monsterTypeNum); // 등장하는 몹의 종류

                mobArray[i] = mobtype;
            }

            return mobArray;
        }

    }

}
