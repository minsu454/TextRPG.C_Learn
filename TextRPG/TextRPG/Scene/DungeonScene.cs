using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using static TextRPG.Monster;

namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        private int shiftCount;
        public override void Load()
        {
            Console.WriteLine("던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");
            Console.WriteLine("1. 전투 시작");
            Console.WriteLine("2. 재정비\n");

            int input = Input.InputKey(2);

            if (input == 1 )
            {
                GameManager.Stage.Spawn();

                InDungeon();
            }
            
            GameManager.Scene.OpenScene(SceneType.Lobby);
        }



        public void InDungeon() // 던전 함수
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Battle!\n");
            Console.ResetColor();

            int mobcount = GameManager.Stage.MobCount().Length;

            for (int i = 0; i < mobcount; i++)
            {
                try
                {
                    Console.WriteLine($"Lv.{GameManager.Stage.monsters[i].Level} {GameManager.Stage.monsters[i].Name} Hp {GameManager.Stage.monsters[i].Health}"); // hp 값 가져오기?
                }

                catch { } // 예외처리
            }

            Console.WriteLine("\n\n[내정보]\n");

            Console.Write("Lv. "); // Player level 값 없음?
            Console.Write("  " + GameManager.player.playerName + " " + "(" + GameManager.player.playerJob + ")" + "\n"); // Player name "안녕", job "전사" 로 고정되어있음?

            Console.WriteLine("Hp " + $"{GameManager.player.playerCurHealth}" + "/" + $"{GameManager.player.playerMaxHealth}" + "\n");

            Console.WriteLine("1. 공격\n");

            Console.ReadLine(); // 입력 받는 곳 , 전투 시작

        }
    }
}
