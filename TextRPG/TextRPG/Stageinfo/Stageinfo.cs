namespace TextRPG
{
    public class StageInfo
    {
        public int stagecount = 1; // 스테이지, 전투 쪽 코드에서 승리시 > 이 값 ++

        public List<Monster> monsters = new List<Monster>();

        public int[] MobCount() // 몹 랜덤
        {
            Random random = new Random();

            int mobcount = random.Next(1, 4); // 등장하는 몹의 수

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
                else if (arr[i] == 1)
                {   
                    int moblevel = random.Next(1, 5); // 레벨 1~4 랜덤

                    monsters.Add(new Goblin(moblevel, "Goblin"));
                }
                 else if (arr[i] == 2)
                {
                    int moblevel = random.Next(1, 5); // 레벨 1~4 랜덤

                    monsters.Add(new RandomBox(moblevel, "RandomBox"));
                }
                  else
                {
                    int moblevel = random.Next(1, 5); // 레벨 1~4 랜덤

                    monsters.Add(new Cobra(moblevel, "Cobra"));
                }

            }
        }

        public int[] MobReturn(int mobCount)
        {
            int[] mobArray = new int[mobCount];

            for (int i = 0; i < mobCount; i++)

            {
                Random random = new Random();

                int mobtype = random.Next(0, 4); // 등장하는 몹의 종류

                mobArray[i] = mobtype;
            }

            return mobArray;
        }

    }

}
