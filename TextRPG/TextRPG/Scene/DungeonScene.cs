using System.Numerics;
using static TextRPG.StageInfo;

namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        List<Monster> monsters = GameManager.Stage.monsters;

        List<Stage> stages = GameManager.Stage.stages;

        private int MonsterIndex = 0;
        private bool isClear = false;
        private int exp = 0;

        public override void Load()
        {
            isClear = false;

            Print.ColorPrintScreen(ConsoleColor.Red, "던전에 오신 여러분 환영합니다.");
            Print.ColorPrintScreen(ConsoleColor.Red, $"이제 전투를 시작할 수 있습니다. [현재 : {GameManager.player.StageNum}층]\n");
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

                // 공격력 10% +- 오차범위 랜덤
                int atkdamage = random.Next(player.playerAttack - player.playerAttack / 10, (player.playerAttack + player.playerAttack / 10) + 1);

                PlayerAttack(atkdamage);
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

        public void PlayerAttack(int atkdamage) // 플레이어 공격 함수
        {
            Player player = GameManager.player;
            int idx = 0;
            int mobCurHealth = monsters[idx].Health;

            while (true)
            {
                idx = Input.InputKey(monsters.Count) - 1;

                if (!monsters[idx].IsDead)
                {
                    break;
                }

                Console.WriteLine();
                Print.ColorPrintScreen(ConsoleColor.Red, "올바른 대상을 지정해주세요.");
            }

            Console.Clear();

            NormalAttack(player, idx, atkdamage); // NormalAttack 테스트용
        }


        private void NormalAttack(Player player, int idx, int atkdamage) // 플레이어 기본 공격
        {
                 
            Random random = new Random();

            bool dodge = random.Next(100) < player.playerDodge; // 빗나갈 확률 , player 기본값 10

            if (dodge) // 공격이 빗나갔을때
            {
                Console.WriteLine($"{player.playerName} 의 공격이 빗나갔습니다!");

                return; // 공격 중단
            }

            bool critical = random.Next(100) < player.playerCritical; // 치명타 확률 , player 기본값 15

            int damagelog = atkdamage; // 데미지 값 반영

            Print.PrintScreenAndSleep($"{player.playerName} 의 공격!\n");

            if (critical) // 치명타가 발생했을때
            {
                damagelog = (int)(atkdamage * 1.6);
                Print.ColorPrintScreen(ConsoleColor.Red, "치명타!!");
            }

            Console.WriteLine($"Lv.{monsters[idx].Level} {monsters[idx].Name} 을(를) 맞췄습니다. [데미지 : {damagelog}]");

            monsters[idx].TakeDamage(damagelog);

            if (monsters[idx].Health <= 0)
            {
                Print.ColorPrintScreen(ConsoleColor.DarkGray, $"Hp {monsters[idx].Health + damagelog} -> Dead\n");

                exp += monsters[idx].Exp;

                GameManager.Event.Dispatch(GameEventType.KillMonster, new KillMonsterEventArgs()
                {
                    Name = $"{monsters[idx].Name}",
                    Count = 1
                });
            }
            else
            {
                Console.WriteLine($"Hp {monsters[idx].Health + damagelog} -> {monsters[idx].Health}\n");
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
            Console.Write($"Lv. {player.level} {player.playerName} ");

            player.playerCurHealth -= monsters[MonsterIndex].Attack;

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
            Console.WriteLine($"보상으로 {stages[GameManager.player.StageNum - 1].gold} Gold를 획득하였습니다!"); // 클리어 보상

            GameManager.player.playerGold += stages[GameManager.player.StageNum - 1].gold;

            if (GameManager.player.StageNum < GameManager.Stage.stages.Count)
                GameManager.player.StageNum++;

            GameManager.player.GetExp(exp);

            Thread.Sleep(500);
        }
    }
}
