using System.Text;
using System.Xml.Linq;

namespace TextRPG
{
    public class StartScene : BaseScene, IMainScene
    {
        private int shiftCount = 0;
        private bool jobSelected = false; // 직업이 선택되었는지 여부 확인 안되었으면 stay

        public override void Load()
        {
            Console.WriteLine("반갑습니다. Player");
            Console.Write("이름을 입력해주세요: ");
            string playerName = Console.ReadLine()!;

            ChooseJob(playerName);

            GameManager.Scene.OpenScene(SceneType.Lobby);
        }

        // 직업 선택 메서드
        public void ChooseJob(string playerName)
        {
            while (!jobSelected)//검사를 하는 동안
            {
                Console.Clear();

                Console.WriteLine($"{playerName}님, 어떤 직업을 선택하시겠습니까?");
                Console.WriteLine("1. 전사\n2. 궁수\n3. 마법사\n4. 도적");
                Console.WriteLine("숫자 1~4 중 하나를 입력하여 직업을 선택하세요.");

                // 사용자 입력 대기
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        ShowJobDetails("전사", 10, 10, 80, 1500);
                        GameManager.player = new Player(playerName!, "전사", 10, 10, 80, 1500);
                        break;
                    case ConsoleKey.D2:
                        ShowJobDetails("궁수", 12, 8, 90, 1500);
                        GameManager.player = new Player(playerName!, "궁수", 12, 8, 90, 1500);
                        break;
                    case ConsoleKey.D3:
                        ShowJobDetails("마법사", 15, 5, 60, 1500);
                        GameManager.player = new Player(playerName!, "전사", 15, 5, 60, 1500);
                        break;
                    case ConsoleKey.D4:
                        ShowJobDetails("도적", 13, 7, 70, 1500);
                        GameManager.player = new Player(playerName!, "전사", 13, 7, 70, 1500);
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                        break;
                }
            }
        }

        // 직업의 성능을 보여주고 선택을 관리하는 메서드
        public void ShowJobDetails(string job, int attack, int defense, int health, int gold)//각 직업 스테이터스 보여주기
        {
            Console.WriteLine($"\n직업: {job}\n공격력: {attack}\n방어력: {defense}\n체력: {health}\n소지금: {gold}G\n");
            Console.WriteLine("1. 선택하기\n2. 뒤로가기");

            ConsoleKeyInfo actionKeyInfo = Console.ReadKey(true);

            if (actionKeyInfo.Key == ConsoleKey.D1)
            {
                Console.WriteLine($"{job}를 선택하셨습니다.");
                jobSelected = true; // 직업 선택 완료
            }
            else if (actionKeyInfo.Key == ConsoleKey.D2)
            {
                Console.WriteLine("직업 선택 화면으로 돌아갑니다.");
                // "뒤로가기"를 선택하면 다시 직업 선택 화면으로 돌아감
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
            }

            Thread.Sleep(500);
        }
    }
}


