using System;
using System.Numerics;
using static TextRPG.StageManager;

namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        private List<Monster> monsters = GameManager.Stage.monsters;

        private Random random = new Random();
        private Player player;

        private int MonsterIndex = 0;
        private bool isClear = false;
        private int totalExp = 0;
        private const int plusMp = 5;

        public override void Load()
        {
            isClear = false;
            totalExp = 0;
            player = GameManager.player;

            Print.ColorPrintScreen(ConsoleColor.Red, "던전에 오신 여러분 환영합니다.");
            Print.ColorPrintScreen(ConsoleColor.Red, $"이제 전투를 시작할 수 있습니다. [현재 : {player.StageNum}층]\n");
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
                GameManager.Event.Dispatch(GameEventType.StageClear, new StageClearEventArgs()
                { 
                    totalExp = totalExp,
                });

            GameManager.Scene.OpenScene(SceneType.Lobby);
        }

        public void InDungeon() // 던전 함수
        {
            if (player.playerCurHealth <= 0)
            {
                throw new ArgumentNullException(player.playerCurHealth.ToString());
            }

            Console.Clear();

            while (!isClear)
            {
                PlayerAttack();
                Thread.Sleep(500);

                MonsterAttack();

                EndRound();
                Print.ColorPrintScreen(ConsoleColor.DarkGreen, "아무키나 누르세요.");
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// 토탈 플레이어 공격
        /// </summary>
        public void PlayerAttack()
        {
            int input = 0;
            
            // 공격력 10% +- 오차범위 랜덤
            int atkdamage = random.Next(player.playerAttack - player.playerAttack / 10, (player.playerAttack + player.playerAttack / 10) + 1);

            while (true)
            {
                PrintBattle();
                input = Input.Selection(1, "공격", "스킬");
                Console.WriteLine("\n");

                if (input == 1)
                {
                    NormalAttack(atkdamage);
                    return;
                }

                var skillList = player.Skill();

                int i;
                for (i = 0; i < skillList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {skillList[i].Name} [-{skillList[i].Mp} Mp]");
                }

                Console.WriteLine($"{i + 1}. 돌아가기\n");
                input = Input.InputKey(i + 1);

                if (input == i + 1)
                {
                    continue;
                }

                Console.WriteLine();

                if (0 <= player.playerCurMp - skillList[input - 1].Mp)
                {
                    SkillAttack(skillList[input - 1], atkdamage);
                    break;
                }
                else
                {
                    Print.ColorPrintScreen(ConsoleColor.Red, "마나가 없습니다.");
                    Thread.Sleep(500);
                }
            }
        }

        private void NormalAttack(int atkdamage, string skillName = "공격") // 플레이어 기본 공격
        {
            int idx = AttackMonsterIdx();

            bool dodge = random.Next(100) < player.playerDodge; // 빗나갈 확률 , player 기본값 10

            if (dodge) // 공격이 빗나갔을때
            {
                Console.WriteLine($"{player.playerName} 의 공격이 빗나갔습니다!");
                return; // 공격 중단
            }

            Print.PrintScreenAndSleep($"{player.playerName} 의 {skillName}!\n");

            bool critical = random.Next(100) < player.playerCritical; // 치명타 확률 , player 기본값 15

            if (critical) // 치명타가 발생했을때
            {
                atkdamage = (int)(atkdamage * 1.6);
                Print.ColorPrintScreen(ConsoleColor.Red, "치명타!!");
            }

            PrintGetMonsterDamage(idx, atkdamage);
        }
        
        /// <summary>
        /// 스킬 공격 함수
        /// </summary>
        public void SkillAttack(ISkill skill, int attack)
        {
            player.playerCurMp -= skill.Mp;

            if (skill.TargetType == TargetType.Single)
            {
                NormalAttack(skill.Use(attack), skill.Name);
            }
            else 
            {
                Console.Clear();
                Print.PrintScreenAndSleep($"{player.playerName} 의 {skill.Name}!\n");
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (monsters[i].IsDead)
                        continue;

                    PrintGetMonsterDamage(i, skill.Use(attack));

                    if (monsters[i].Name == "Cobra")
                    {
                        Cobra cobra = monsters[i] as Cobra;
                        cobra.ReceiveAttack();
                    }
                }
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

            int playerCurHealth = player.playerCurHealth;

            Console.WriteLine();
            Print.PrintScreenAndSleep($"Lv.{monsters[MonsterIndex].Level} {monsters[MonsterIndex].Name} 의 공격!\n");
            Console.WriteLine($"{player.playerName} 을(를) 맞췄습니다. [데미지 : {monsters[MonsterIndex].Attack}]");
            Console.Write($"Lv. {player.level} {player.playerName} ");

            int attack = monsters[MonsterIndex].Attack - (player.playerDefense * 10 / 100);
            
            if (attack <= 0)
                attack = 0;

            player.playerCurHealth -= attack;

            if (player.playerCurHealth <= 0)
            {
                Print.ColorPrintScreen(ConsoleColor.DarkGray, $"Hp {playerCurHealth} -> Dead\n");
                player.playerCurHealth = 0;
                return;
            }

            Console.WriteLine($"Hp {playerCurHealth} -> {player.playerCurHealth}\n");

            MonsterIndex = (++MonsterIndex) % monsters.Count;

            if (player.playerCurHealth <= 0) // 플레이어가 죽었는지 확인
            {
                Console.WriteLine($"{player.playerName}이(가) 쓰러졌습니다!\n");
                Console.WriteLine("마지막으로 저장된 곳으로 이동하시겠습니까?\n");

                int input = Input.Selection(1, "예.", "아니오.");

                if (input == 1)
                {
                    GameManager.player = GameManager.Save.Load<Player>();
                }
                else
                {
                    GameManager.isRun = false;
                }
            }
        }

        /// <summary>
        /// 배틀 출력해주는 함수
        /// </summary>
        public void PrintBattle()
        {
            Console.Clear();

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
            Console.WriteLine($"Hp {player.playerCurHealth} / {player.playerMaxHealth}");
            Console.WriteLine($"Mp {player.playerCurMp} / {player.playerMaxMp}      (+{plusMp})\n");
        }

        /// <summary>
        /// 몬스터 데미지 받는 출력 함수
        /// </summary>
        private void PrintGetMonsterDamage(int idx, int atkdamage)
        {
            Console.WriteLine($"Lv.{monsters[idx].Level} {monsters[idx].Name} 을(를) 맞췄습니다. [데미지 : {atkdamage}]");
            monsters[idx].TakeDamage(atkdamage);

            if (monsters[idx].Name == "Cobra")
            {
                Cobra cobra = monsters[idx] as Cobra;
                cobra.ReceiveAttack();
            }

            if (monsters[idx].IsDead)
            {
                Print.ColorPrintScreen(ConsoleColor.DarkGray, $"Hp {monsters[idx].Health + atkdamage} -> Dead\n");

                totalExp += monsters[idx].Exp;
                GameManager.Event.Dispatch(GameEventType.KillMonster, new KillMonsterEventArgs()
                {
                    Name = $"{monsters[idx].Name}",
                    Count = 1
                });
            }
            else
            {
                Console.WriteLine($"Hp {monsters[idx].Health + atkdamage} -> {monsters[idx].Health}\n");
            }
        }

        /// <summary>
        /// 대상을 선택하는 함수
        /// </summary>
        public int AttackMonsterIdx()
        {
            int idx = 0;
            Console.WriteLine("대상을 선택해주세요.\n");

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

            return idx;
        }

        /// <summary>
        /// 라운드가 끝났을때 호출(양쪽이 모두 공격하고 나서)
        /// </summary>
        public void EndRound()
        {
            player.PlusMp(plusMp);
        }
    }
}
