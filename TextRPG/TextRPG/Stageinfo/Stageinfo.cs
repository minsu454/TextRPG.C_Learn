namespace TextRPG
{
    internal class Stageinfo
    {
        public class StageInfo
        {
            // mob 쪽 코드 작성되면 옮길 곳 , 지금은 출력을 위한 예시

            public static string[] mobname = new String[] { "name1", "name2", "name3" }; // 몹 이름
            public static int[] moblevel = new int[] { 1, 2, 3 }; // 몹 레벨
            public static int[] mobatk = new int[] { 1, 2, 3 }; // 몹 공격력
            public static int[] mobdef = new int[] { 1, 2, 3 }; // 몹 방어력
            public static int[] mobhp = new int[] { 1, 2, 3 }; // 몹 체력


            public int stagecount = 1; // 스테이지
            public static void MobCount() // 몹 종류, 수 랜덤 함수
            {
                Random random = new Random();

                int mobcount = random.Next(1, 4); // 등장하는 몹의 수

                while (!(mobcount < 1))
                {
                    Random random1 = new Random();

                    int mobtype = random1.Next(0, 3); // 등장하는 몹의 종류

                    Console.WriteLine("Lv:" + moblevel[mobtype] + mobname[mobtype] + "Hp:" + mobhp[mobtype]); // 출력

                    mobcount--;
                }

            }
        }

    }
}
