namespace TextRPG
{
    public class StageInfo
    {
        public List<Stage> stages = new List<Stage>();

        public List<Monster> monsters = new List<Monster>();
        public StageInfo()
        {
            stages.Add(new Stage(500, 1, 2));  // 스테이지 1
            stages.Add(new Stage(1000, 2, 3)); // 스테이지 2
            stages.Add(new Stage(1500, 3, 5)); // 스테이지 3
            stages.Add(new Stage(2000, 4, 6)); // 스테이지 4
        }
        public int[] MobCount() // 몹 랜덤
        {
            int nowstage = GameManager.player.StageNum;
            
            Random random = new Random();

            int mobcount = random.Next(stages[nowstage -1].mobMinCount, stages[nowstage -1].mobMaxCount + 1); // 등장하는 몹의 수

            return MobReturn(mobcount);
        }

        public void Spawn()
        {
            monsters.Clear();

            int[] arr = MobCount();

            Random random = new Random();

            for (int i = 0; i < arr.Length; i++) // arr (return 받아온 배열)로 몹 종류 정하기
            {
                if (arr[i] == 0)
                {   
                    int moblevel = random.Next(1, 5); // 레벨 1~4 랜덤

                    monsters.Add(new Ork(moblevel, "Ork"));
                }
                else
                {   
                    int moblevel = random.Next(1, 5); // 레벨 1~4 랜덤

                    monsters.Add(new Goblin(moblevel, "Goblin"));
                }


            }
        }

        public int[] MobReturn(int mobCount)
        {
            int[] mobArray = new int[mobCount];

            for (int i = 0; i < mobCount; i++)

            {
                Random random = new Random();

                int mobtype = random.Next(0, 2); // 등장하는 몹의 종류

                mobArray[i] = mobtype;
            }

            return mobArray;
        }

    }

}
