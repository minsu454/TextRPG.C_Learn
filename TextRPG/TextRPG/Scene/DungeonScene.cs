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

                switch (input)
                {
                    case 1: // 1번 몹 선택시

                        DungeonStart(atkdamage, 0);
                        break;

                    case 2: // 2번 몹 선택시

                        DungeonStart(atkdamage, 1);
                        break;

                    case 3: // 3번 몹 선택시

                        DungeonStart(atkdamage, 2);
                        break;

                    default: // 그 외
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("올바른 대상을 지정해주세요.\n");
                        Console.ResetColor();
                        break;

                }

                if (monsters.All(alldead => alldead.IsDead)) // 모든 몹 죽었을때 로비로 돌아가기
                {
                    Console.WriteLine("\n1. 나가기\n");
                    
                    int input2 = Input.InputKey(1, 1);

                    switch (input2)
                    {
                        case 1:
                            GameManager.Scene.OpenScene(SceneType.Lobby);
                            break;

                        default:
                            
                            break;
                    }

                    break;
                }

                if (player.playerCurHealth <= 0) // 플레이어가 죽었는지 확인
                {
                    Console.WriteLine($"{player.playerName}이(가) 쓰러졌습니다!");

                    Console.WriteLine("\n1. 나가기\n");

                    int input3 = Input.InputKey(1, 1);

                    switch (input3)
                    {
                        case 1:
                            GameManager.Scene.OpenScene(SceneType.Lobby);
                            break;

                        default:

                            break;
                    }

                    break;
                }

                continue;

            }

        }

        private int MonsterIndex = 0; // 몹 순차적 공격 위한 값
        public void DungeonStart(int atkdamage, int index) // 공격 함수
        {
            Player player = GameManager.player;

            if (!monsters[index].IsDead)
            {
                Console.Clear();

                int mobCurHealth = monsters[index].Health;

                Console.WriteLine(GameManager.player.playerName + "의 공격!");

                monsters[index].Health -= atkdamage; // 테스트 시 공격력 수정하는 곳

                Console.WriteLine($"Lv.{monsters[index].Level} {monsters[index].Name} 을(를) 맞췄습니다. [데미지 : {atkdamage}]");
                Console.WriteLine($"Hp {mobCurHealth} -> {monsters[index].Health}\n");

                while (true) // 플레이어에게 공격할 몬스터 선택
                {
                    if (monsters[MonsterIndex].Health > 0) 
                    {
                        int playerCurHealth = player.playerCurHealth;

                        Thread.Sleep(500);

                        Console.WriteLine($"Lv.{monsters[MonsterIndex].Level} {monsters[MonsterIndex].Name} 의 공격!");
                        Console.WriteLine(player.playerName + "을(를) 맞췄습니다. [데미지 : "+$"{monsters[MonsterIndex].Attack}"+"]");

                        player.playerCurHealth -= monsters[MonsterIndex].Attack;

                        Console.Write("Lv. " + player.level + " " + player.playerName);
                        Console.WriteLine("Hp " + playerCurHealth + " -> " + $"{player.playerCurHealth}\n");

                        Thread.Sleep(500);

                        MonsterIndex = (MonsterIndex + 1) % monsters.Count; // 몬스터 한턴 한마리씩 공격

                        break;
                    }

                    MonsterIndex = (MonsterIndex + 1) % monsters.Count; // 현재 몬스터가 죽으면? 다음 몬스터가 공격

                    if (monsters.All(alldead => alldead.IsDead))
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Win!\n");
                        Console.ResetColor();

                        for (int i = 0; i < monsters.Count; i++)
                        {
                            if (monsters[i].IsDead)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name} Dead");
                                Console.ResetColor();
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n모든 몬스터를 처치했습니다!");
                        Console.ResetColor();
                        // 전투 종료시 ?

                        GameManager.Scene.OpenScene(SceneType.Lobby);

                        return; // 전투 종료
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("올바른 대상을 지정해주세요.\n");
                Console.ResetColor();
            }
        }
    }
}
