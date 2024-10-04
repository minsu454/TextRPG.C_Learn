using System;
using System.Text; // UTP-8 이모지 때문에 사용

namespace TextRPG
{
    public class GamblingScene : BaseScene
    {
        private static readonly string[] emoji = { "7️", "💀", "🌸", "🌟", "❄️" };

        private Random random = new Random();
        public override void Load() // 메인 함수
        {
            Player player = GameManager.player;

            Console.OutputEncoding = Encoding.UTF8; // 이모지 안나오는거 방지

            Print.ColorPrintScreen(ConsoleColor.Yellow, "도박장에 오신 것을 환영합니다!\n");

            Print.ColorPrintScreen(ConsoleColor.Yellow, "100 Gold를 내고 슬롯머신을 1회 사용 할 수 있습니다.\n");

            Print.ColorPrintScreen(ConsoleColor.Yellow, "성공시 배팅금 5배! 잭팟시 배팅금 10배!\n");

            Print.ColorPrintScreen(ConsoleColor.Yellow, $"현재 소지금 : {player.playerGold} Gold\n");

            Console.WriteLine("\n----- 슬롯 머신 ------");
            Console.WriteLine($"    | 7 | 7 | 7 |");
            Console.WriteLine("----------------------\n");

            bool replay = true; // 게임 반복 여부

            while (replay)
            {
                replay = PlayGambling(); // 슬롯 머신 게임 실행
            }

            GameManager.Scene.OpenScene(SceneType.Lobby); // 필요할때 주석
        }

        private bool PlayGambling() // 게임 진행
        {
            Console.WriteLine("\n슬롯 머신을 돌리시겠습니까? \n\n1. 예\n\n2. 나가기\n");

            int input = Input.InputKey(2, 1);

            switch (input)
            {
                case 1: break; // 슬롯 머신 돌리기
                case 2: return false; // 로비로 돌아가기
            }

            Console.Clear();

            string[] result = Roll(); // Roll() 값 결과에 넣기

            Resultprint(result); // 결과 출력

            GamblingResult(result); // 잭팟 체크

            return true; // 다시 게임을 할 수 있도록 true 반환
        }

        private string[] Roll() // 무작위 이모지 산출 후 배열에 넣기
        {
            Player player = GameManager.player;

            if (player.playerGold >= 500)
            {
                player.playerGold -= 500;

                string[] result = new string[3]; // 결과 저장

                for (int i = 0; i < result.Length; i++) // 랜덤으로 기호 선택
                {
                    result[i] = emoji[random.Next(emoji.Length)]; // 0 > 길이까지
                }
                return result; // 반환
            }

            else // 소지금 없을때 예외처리
            {
                Console.SetCursorPosition(0, 8);
                Print.ColorPrintScreen(ConsoleColor.Red, "소지금이 부족합니다! 슬롯 머신을 돌릴 수 없습니다."); 

                Console.SetCursorPosition(0, 0);
                return new string[] { "❌", "❌", "❌" };
            }
        }

        private void Resultprint(string[] result) // 출력 UI
        {
            // 결과 출력
            Player player = GameManager.player;

            Print.ColorPrintScreen(ConsoleColor.Yellow, $"현재 소지금 : {player.playerGold} Gold\n"); // 1번째 줄 

            Console.WriteLine("\n----- 슬롯 머신 ------"); //4번째 줄

            Console.WriteLine("   |    |    |    |"); // 임시 5번째 줄

            Console.WriteLine("----------------------\n"); // 6번째 줄

            Console.SetCursorPosition(0, 4);
            Thread.Sleep(500);
            Console.Write($"   | {result[0]} | "); // 5번째 줄 

            Thread.Sleep(500);
            Console.Write($"{result[1]} | "); // 5번째 줄 

            Thread.Sleep(500);
            Console.WriteLine($"{result[2]} |");  // 5번째 줄 

            Console.SetCursorPosition(0, 8); // 줄 이동
        }

        private void GamblingResult(string[] result) // 게임 결과
        {
            if (result[0] == "❌" || result[1] == "❌" || result[2] == "❌") // 소지금 부족시 "❌" 이모지 읽히는 문제 감지
            {
                return;
            }

            if (result[0] == result[1] && result[1] == result[2])
            {
                if (result[0] == "7️")
                {
                    Console.WriteLine("잭팟! 배팅금의 100배를 획득했습니다!");

                    GameManager.player.playerGold += 10000;
                }
                else
                {
                    Console.WriteLine("축하합니다! 배팅금의 10배를 획득하셨습니다.");

                    GameManager.player.playerGold += 1000;
                }
            }
            else
            {
                Console.WriteLine("다음 기회를 노려주세요");
            }
        }
    }
}
