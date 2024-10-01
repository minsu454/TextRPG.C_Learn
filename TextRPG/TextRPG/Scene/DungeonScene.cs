namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        private int shiftCount;

        List<Monster> monsters = GameManager.Stage.monsters;

        Player player = GameManager.player;
        public override void Load()
        {
            Console.WriteLine("던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");
            Console.WriteLine("1. 전투 시작");
            Console.WriteLine("2. 재정비\n");

            int input = Input.InputKey(2, 1);

            switch (input)
            {
                case 1:
                    GameManager.Stage.Spawn();
                    InDungeon();
                    break;

                default:
                    GameManager.Scene.OpenScene(SceneType.Lobby);
                    break;
            }
        }
        public void InDungeon() // 던전 함수
        {
            Player player = GameManager.player;

            Console.Clear();

            while (true)
            {
                if (player.playerCurHealth > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Battle!\n");
                    Console.ResetColor();

                    for (int i = 0; i < monsters.Count; i++)
                    {
                        if (monsters[i].IsDead)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name} Dead");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name} Hp {monsters[i].Health}");
                        }
                    }

                    Console.ResetColor();

                    Console.WriteLine("\n\n[내정보]\n");

                    Console.Write($"Lv. {player.level}");

                    Console.Write($" {player.playerName} {player.playerJob} \n");

                    Console.WriteLine($"Hp {player.playerCurHealth} / {player.playerMaxHealth}" + "\n");

                    Console.WriteLine("대상을 선택해주세요.\n");

                    int input = Input.InputKey(monsters.Count, 1);

                    Random random = new Random();

                    int atkdamage = random.Next(player.playerAttack - player.playerAttack / 10, (player.playerAttack + player.playerAttack / 10) + 1);

                    // 공격력 10% +- 오차범위 랜덤

                    if (1 <= input && input <= 3)
                    {
                        PlayerAttack(atkdamage, input - 1);
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("올바른 대상을 지정해주세요.\n");
                        Console.ResetColor();
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("체력이 부족해 던전에 입장 할 수 없습니다.\n\n1. 나가기\n"); // 체력 <= 0 입장제한

                    int input2 = Input.InputKey(1, 1);

                    GameManager.Scene.OpenScene(SceneType.Lobby);

                    break;
                }

                if (monsters.All(alldead => alldead.IsDead)) // 모든 몹 죽었을때 로비로 돌아가기
                {
                    Console.WriteLine("\n1. 나가기\n");

                    int input2 = Input.InputKey(1, 1);

                    GameManager.Scene.OpenScene(SceneType.Lobby);

                    break;
                }

                if (player.playerCurHealth <= 0) // 플레이어가 죽었는지 확인
                {
                    Console.WriteLine($"{player.playerName}이(가) 쓰러졌습니다!");

                    Console.WriteLine("\n1. 나가기\n");

                    GameManager.player = GameManager.Save.Load<Player>();

                    int input2 = Input.InputKey(1, 1);

                    GameManager.Scene.OpenScene(SceneType.Lobby);

                    break;
                }
                continue;
            }
        }

        public void PlayerAttack(int atkdamage, int index) // 플레이어 공격 함수
        {
            Player player = GameManager.player;

            if (!monsters[index].IsDead)
            {
                Console.Clear();

                int mobCurHealth = monsters[index].Health;

                Console.WriteLine($"{player.playerName} 의 공격!");

                Thread.Sleep(500);

                monsters[index].Health -= atkdamage; // 테스트 시 공격력 수정하는 곳

                Console.WriteLine($"Lv.{monsters[index].Level} {monsters[index].Name} 을(를) 맞췄습니다. [데미지 : {atkdamage}]");

                if (monsters[index].Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Hp {mobCurHealth} -> Dead\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Hp {mobCurHealth} -> {monsters[index].Health}\n");
                }

                Thread.Sleep(500);

                MonsterAttack();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("올바른 대상을 지정해주세요.\n");
                Console.ResetColor();
            }
        }

        private int MonsterIndex = 0;
        public void MonsterAttack() // 몹 공격 함수
        {
            for (int i = 0; i < monsters.Count; i++) // 살아있는 몬스터 찾아서 공격 시도할때까지 반복
            {

                if (!monsters[MonsterIndex].IsDead) // 현재 몬스터가 살아있다면 공격 진행
                {
                    Player player = GameManager.player;

                    int playerCurHealth = player.playerCurHealth;

                    Console.WriteLine($"Lv.{monsters[MonsterIndex].Level} {monsters[MonsterIndex].Name} 의 공격!");

                    Thread.Sleep(500);

                    Console.WriteLine($"{player.playerName} 을(를) 맞췄습니다. [데미지 : {monsters[MonsterIndex].Attack}]");

                    player.playerCurHealth -= monsters[MonsterIndex].Attack;

                    Console.Write($"Lv. {player.level} {player.playerName} ");

                    if (player.playerCurHealth <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"Hp {playerCurHealth} -> Dead\n");
                        Console.ResetColor();
                        player.playerCurHealth = 0;
                    }
                    else
                    {
                        Console.WriteLine($"Hp {playerCurHealth} -> {player.playerCurHealth}\n");
                    }

                    Thread.Sleep(500);

                    break; // 공격 후 루프 종료
                }
                MonsterIndex = (MonsterIndex + 1) % monsters.Count;
            }

            if (monsters.All(alldead => alldead.IsDead))
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Win!\n");

                Console.ResetColor();
            }

        }
    }
}
