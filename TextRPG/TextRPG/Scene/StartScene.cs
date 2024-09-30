using System.Text;
using System.Xml.Linq;

namespace TextRPG
{
    public class StartScene : BaseScene, IMainScene
    {
        private int shiftCount = 0;
        private string playerName;
        private bool jobSelected = false;



        public override void Load()
        {
            Console.WriteLine((int)GameEventType.None);
            if (string.IsNullOrEmpty(playerName)) // 직업 선택에서 뒤로가기 누를 시 이름 입력하는 창으로 이동하기에 아예 한 번 이름 입력하면 이동 안하게 고정
            {
                Console.WriteLine("반갑습니다. Player");
                Console.Write("이름을 입력해주세요: ");
                playerName = Console.ReadLine();

                ChooseJob();
                GameManager.Scene.OpenScene(SceneType.Lobby);
            }

        }

        public void ChooseJob()
        {


            Console.WriteLine($"{playerName}님, 어떤 직업을 선택하시겠습니까?");
            Console.WriteLine("1. 전사\n2. 궁수\n3. 마법사\n4. 도적");
            Console.WriteLine("숫자 1~4 중 하나를 입력하여 직업을 선택하세요.");

            int keyInfo = Input.InputKey(4);

            switch (keyInfo)
            {
                case 1:
                    ShowJobDetails("전사", 10, 10, 80, 1500);
                    break;
                case 2:
                    ShowJobDetails("궁수", 12, 8, 90, 1500);
                    break;
                case 3:
                    ShowJobDetails("마법사", 15, 5, 60, 1500);
                    break;
                case 4:
                    ShowJobDetails("도적", 13, 7, 70, 1500);
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 다시 입력해주세요.");
                    break;
            }


        }

        public void ShowJobDetails(string job, int attack, int defense, int health, int gold)
        {
            Console.WriteLine($"\n직업: {job}\n공격력: {attack}\n방어력: {defense}\n체력: {health}\n소지금: {gold}G");
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
                // 뒤로가기 선택 시 직업 선택 화면으로 돌아감
                ChooseJob();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                ShowJobDetails(job, attack, defense, health, gold);
            }
        }
    }
}


