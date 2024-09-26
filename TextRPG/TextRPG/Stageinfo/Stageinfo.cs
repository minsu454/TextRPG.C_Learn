namespace TextRPG.Stageinfo
{
    internal class Stageinfo
    {
        public class stageinfo
        {
            // mob 쪽 코드 작성되면 옮길 곳 , 지금은 출력을 위한 예시

            public string[] mobname = new String[] { "name1", "name2", "name3" }; // 몹 이름
            public int[] moblevel = new int[] { 1, 2, 3 }; // 몹 레벨
            public int[] mobatk = new int[] { 1, 2, 3 }; // 몹 공격력
            public int[] mobdef = new int[] { 1, 2, 3 }; // 몹 방어력
            public int[] mobhp = new int[] { 1, 2, 3 }; // 몹 체력

            public int stagecount = 1; // 스테이지
        }
        static void Main(string[] args)
        {
            stageinfo stageinfo = new stageinfo();

            void InDungeon() // 던전 입장 시 
            {

                // 전투 쪽 UI 띄울 곳

                while (true) // 몹 등장 수 , 종류 랜덤 설정
                {
                    Random random = new Random();

                    int mobcount = random.Next(1, 4); // 등장하는 몹의 수

                    switch (stageinfo.stagecount)
                    {
                        case 1:

                            for (int i = 0; i < mobcount; i++)
                            {
                                Random random1 = new Random();

                                int mobtype = random1.Next(0, 3); // 등장하는 몹의 종류 

                                Console.WriteLine("Lv." + stageinfo.moblevel[mobtype] + " " + stageinfo.mobname[mobtype] + " Hp " + stageinfo.mobhp[mobtype]); // 몹 정보 출력
                            }

                            break;

                    }

                    // 전투 쪽 함수 불러올 곳 

                    // 전투 완료시 결과 출력 , 클리어 시 stageinfo.stagecount++;

                    break;
                }
            }

            InDungeon();

        }

    }
}
