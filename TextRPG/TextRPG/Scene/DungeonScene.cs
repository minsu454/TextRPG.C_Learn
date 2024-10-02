namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        List<Monster> monsters = GameManager.Stage.monsters;
        private int MonsterIndex = 0;
        private bool isClear = false;
        private int exp = 0;

        public override void Load()
        {
            isClear = false;

            Console.WriteLine("던전에 오신 여러분 환영합니다.");
            Console.WriteLine($"이제 전투를 시작할 수 있습니다. [현재 : {GameManager.player.StageNum}층]\n");
            Console.WriteLine("1. 전투 시작");
            Console.WriteLine("2. 재정비\n");

            int input = Input.InputKey(2, 1);

            switch (input)
            {
                case 1:
                    GameManager.Stage.Spawn();
                    InDungeon();
                    break;
            }

            if (isClear)
                DungeonClear();

            GameManager.Scene.OpenScene(SceneType.Lobby);
        }

        public void InDungeon() // 던전 함수
        {
            Player player = GameManager.player;
            Random random = new Random();
            int input = 0;

            Console.Clear();

            while (!isClear)
            {
                if (player.playerCurHealth <= 0)
                {
                    Console.WriteLine("체력이 부족해 던전에 입장 할 수 없습니다.\n\n1. 나가기\n"); // 체력 <= 0 입장제한

                    input = Input.InputKey(1, 1);
                    break;
                }

                Print.ColorPrintScreen(ConsoleColor.DarkYellow, "Battle!\n");

                for (int i = 0; i < monsters.Count; i++)
                {
                    if (monsters[i].IsDead)
                    {
                        Print.ColorPrintScreen(ConsoleColor.DarkGray, $"Lv.{monsters[i].Level} {monsters[i].Name} Dead");
                    }
                    else
                    {
                        Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name} Hp {monsters[i].Health}");
                    }
                }
                Console.WriteLine("\n\n[내정보]\n");

                Console.WriteLine($"Lv. {player.level} {player.playerName} {player.playerJob}");

                Console.WriteLine($"Hp {player.playerCurHealth} / {player.playerMaxHealth}\n");

                Console.WriteLine("대상을 선택해주세요.\n");

                input = Input.InputKey(monsters.Count, 1);

                int atkdamage = random.Next(player.playerAttack - player.playerAttack / 10, (player.playerAttack + player.playerAttack / 10) + 1);

                // 공격력 10% +- 오차범위 랜덤

                Console.Clear();

                PlayerAttack(atkdamage, input - 1);
                Thread.Sleep(500);

                MonsterAttack();
                Thread.Sleep(500);

                if (player.playerCurHealth <= 0) // 플레이어가 죽었는지 확인
                {
                    Console.WriteLine($"{player.playerName}이(가) 쓰러졌습니다!\n");

                    Console.WriteLine("마지막으로 저장된 곳으로 이동하시겠습니까?\n");
                    input = Input.Selection(1, "예.", "아니오");

                    if (input == 1)
                    {
                        GameManager.player = GameManager.Save.Load<Player>();
                    }
                    else
                    {
                        GameManager.isRun = false;
                    }
                    break;
                }
            }
        }

        public void PlayerAttack(int atkdamage, int index) // 플레이어 공격 함수
        {
            Player player = GameManager.player;

            if (monsters[index].IsDead)
            {
                Print.ColorPrintScreen(ConsoleColor.Red, "올바른 대상을 지정해주세요.\n");
                return;
            }

            int mobCurHealth = monsters[index].Health;

            Print.PrintScreenAndSleep($"{player.playerName} 의 공격!\n");
            Console.WriteLine($"Lv.{monsters[index].Level} {monsters[index].Name} 을(를) 맞췄습니다. [데미지 : {atkdamage}]");

            monsters[index].TakeDamage(atkdamage);  // 테스트 시 공격력 수정하는 곳

            if (monsters[index].Health <= 0)
            {
                Print.ColorPrintScreen(ConsoleColor.DarkGray, $"Hp {mobCurHealth} -> Dead\n");
                exp += monsters[index].exp;
                GameManager.Event.Dispatch(GameEventType.KillMonster, new KillMonsterEventArgs()
                {
                    Name = $"{monsters[index].Name}",
                    Count = 1
                });
            }
            else
            {
                Console.WriteLine($"Hp {mobCurHealth} -> {monsters[index].Health}\n");
            }
        }

        public void MonsterAttack() // 몹 공격 함수
        {
            if (monsters.All(alldead => alldead.IsDead))
            {
                isClear = true;
                return;
            }

            for (int i = 0; i < monsters.Count; i++) // 살아있는 몬스터 찾아서 공격 시도할때까지 반복
            {
                if (monsters[MonsterIndex].IsDead) // 현재 몬스터가 살아있다면 공격 진행
                {
                    MonsterIndex++;
                    MonsterIndex %= monsters.Count;
                }
                else
                {
                    break;
                }
            }

            Player player = GameManager.player;

            int playerCurHealth = player.playerCurHealth;

            Console.WriteLine();

            Print.PrintScreenAndSleep($"Lv.{monsters[MonsterIndex].Level} {monsters[MonsterIndex].Name} 의 공격!\n");

            Console.WriteLine($"{player.playerName} 을(를) 맞췄습니다. [데미지 : {monsters[MonsterIndex].Attack}]");

            player.playerCurHealth -= monsters[MonsterIndex].Attack;

            Console.Write($"Lv. {player.level} {player.playerName} ");

            if (player.playerCurHealth <= 0)
            {
                Print.ColorPrintScreen(ConsoleColor.DarkGray, $"Hp {playerCurHealth} -> Dead\n");
                player.playerCurHealth = 0;
                return;
            }

            Console.WriteLine($"Hp {playerCurHealth} -> {player.playerCurHealth}\n");
            MonsterIndex = (++MonsterIndex) % monsters.Count;
        }

        public void DungeonClear()
        {
            Console.Clear();
            Print.ColorPrintScreen(ConsoleColor.Green, "Win!\n");
            GameManager.player.StageNum++;

            Thread.Sleep(500);
        }
    }
}
