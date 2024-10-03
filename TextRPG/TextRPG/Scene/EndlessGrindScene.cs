namespace TextRPG
{
    public class EndlessGrindScene : BaseScene
    {
        string[] gameOverArr = new string[] { "G", "A", "M", "E", "O", "V", "E", "R" };
        public override void Load()
        {
            Print.ColorPrintScreen(ConsoleColor.DarkCyan, "여기에서는 노가다를 할 수 있습니다.");

            int input = Input.Selection(1, "예", "아니오");

            if (input == 1)
                InGame();

            GameManager.Scene.CloseScene();
        }

        /// <summary>
        /// 인게임 함수
        /// </summary>
        public void InGame()
        {
            int gold = 0;
            bool isFail = false;

            while (true)
            {
                DirType[] dirArr = RandomArrow(out string printArrow, 10);

                Console.Clear();
                Console.WriteLine($"맞는 화살표를 입력해서 돈을 벌어보자! (화살표 말고 다른 것을 누를 시 게임 오버) 현재 : {gold} G\n");
                Console.WriteLine(printArrow + "\n");

                for (int i = 0; i < dirArr.Length; i++)
                {
                    int input = Input.ReadArrow();

                    if (input < 0 || input >= 4)
                    {
                        isFail = true;
                        break;
                    }

                    DirType dir = (DirType)input;
                    Console.Write($"{PrintArrow(dir)} ");

                    if (dir != dirArr[i])
                    {
                        isFail = true;
                        break;
                    }
                }
                
                if (isFail)
                {
                    break;
                }
                else
                {
                    gold += 10;
                }
            }

            GameOver(gold);
        }

        /// <summary>
        /// 게임 끝났을 때 실행되는 함수
        /// </summary>
        public void GameOver(int gold)
        {
            Console.WriteLine("\n");
            
            for (int i = 0; i < gameOverArr.Length; i++)
            {
                Print.ColorPrintScreen(ConsoleColor.Red, $"{gameOverArr[i]} ", false);
                Thread.Sleep(100);
            }
            Console.WriteLine("\n");
            Print.ColorPrintScreen(ConsoleColor.Yellow, $"{gold} G", false);
            Console.WriteLine("를 획득했습니다.");

            GameManager.player.playerGold += gold;

            Console.WriteLine();
            Print.ColorPrintScreen(ConsoleColor.DarkGreen, "아무키나 누르세요.");
            Console.ReadKey(true);
        }

        /// <summary>
        /// 랜덤 방향키들 반환해주는 함수
        /// </summary>
        public DirType[] RandomArrow(out string print, int count)
        {
            var typeArr = new DirType[count];
            string s = "";
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                DirType type = (DirType)random.Next(0, 4);

                typeArr[i] = type;
                s += $"{PrintArrow(type)} ";
            }

            print = s;
            return typeArr;
        }

        /// <summary>
        /// 화살표 찍어주는 함수
        /// </summary>
        public string PrintArrow(DirType dir)
        {
            string s = "";

            switch (dir)
            {
                case DirType.Up:
                    s = "↑";
                    break;
                case DirType.Down:
                    s = "↓";
                    break;
                case DirType.Left:
                    s = "←";
                    break;
                case DirType.Right:
                    s = "→";
                    break;
            }
            return s;
        }

    }
}

