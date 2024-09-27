namespace TextRPG
{

    public class Player
    {
        public string playerName;
        public string playerJob;
        public int playerAttack;
        public int playerDefense;
        public int playerHealth;
        public int playerGold;

        public void ChooseJob()
        {
            bool jobChosen = false;

            while (!jobChosen)
            {
                Console.WriteLine($"{playerName}님, 어떤 직업을 선택하시겠습니까?");
                Console.WriteLine("1. 전사\n2. 궁수\n3. 마법사\n4. 도적");
                Console.WriteLine("직업의 성능을 확인하시겠습니까? (번호를 선택하세요)");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SetJob("전사", 10, 10, 80, 1500);
                        jobChosen = true;
                        break;
                    case "2":
                        SetJob("궁수", 12, 8, 90, 1500);
                        jobChosen = true;
                        break;
                    case "3":
                        SetJob("마법사", 15, 5, 60, 1500);
                        jobChosen = true;
                        break;
                    case "4":
                        SetJob("도적", 13, 7, 70, 1500);
                        jobChosen = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                        break;
                }
            }
        }

        // 직업 세팅
        public void SetJob(string job, int attack, int defense, int health, int gold)
        {
            playerJob = job;
            playerAttack = attack;
            playerDefense = defense;
            playerHealth = health;
            playerGold = gold;
            Console.WriteLine($"{job}를 선택하셨습니다.");
        }
        // 마을로 이동
        public void GoToVillage()
        {
            Console.WriteLine($"\n환영합니다, {playerName} {playerJob}님, 스파르타 던전에 오신 걸 환영합니다.");
            VillageMenu();
        }

        // 마을 메뉴
        public void VillageMenu()
        {
            while (true)
            {
                Console.WriteLine("\n무엇을 하시겠습니까?");
                Console.WriteLine("1. 상태보기\n2. 인벤토리\n3. 상점\n4. 휴식\n5. 던전 들어가기");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewStatus();
                        break;
                    case "2":
                        ViewInventory();
                        break;
                    case "3":
                    case "4":
                    case "5":
                        Console.WriteLine("활성화되지 않은 기능입니다.");
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 선택해주세요.");
                        break;
                }
            }
        }

        // 상태보기
        public void ViewStatus()
        {
            Console.WriteLine("\n===== 현재 상태 =====");
            Console.WriteLine($"직업: {playerJob}");
            Console.WriteLine($"공격력: {playerAttack}");
            Console.WriteLine($"방어력: {playerDefense}");
            Console.WriteLine($"체력: {playerHealth}");
            Console.WriteLine($"소지금: {playerGold}G");
            Console.WriteLine("=====================");
            Console.WriteLine("1. 돌아가기");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("마을로 돌아갑니다.");
            }
        }

        // 인벤토리 보기
        public void ViewInventory()
        {
            Console.WriteLine("\n===== 인벤토리 =====");
            // 현재 아이템이 없으므로 예시용으로 '없음' 표시
            Console.WriteLine("아이템: 없음");
            Console.WriteLine($"소지금: {playerGold}G");
            Console.WriteLine("=====================");
            Console.WriteLine("1. 돌아가기");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("마을로 돌아갑니다.");
            }
        }
    }

  
}
