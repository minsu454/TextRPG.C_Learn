using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using static TextRPG.Monster;


//********************버그 수정 > 몹이 1마리여도 간헐적으로 1번이 아닌 2, 3을 입력했을때 전투가 진행됨.**************************

namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        private int shiftCount;
        public override void Load()
        {
            Console.WriteLine("던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");
            Console.WriteLine("1. 전투 시작");
            Console.WriteLine("2. 재정비\n");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
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
            Console.Clear();

            int mobcount = GameManager.Stage.MobCount().Length;

            Player player = GameManager.player;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Battle!\n");
                Console.ResetColor();

                for (int i = 0; i < mobcount; i++)
                {
                    try
                    {
                        if (GameManager.Stage.monsters[i].IsDead)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine($"Lv.{GameManager.Stage.monsters[i].Level} {GameManager.Stage.monsters[i].Name} Dead");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"Lv.{GameManager.Stage.monsters[i].Level} {GameManager.Stage.monsters[i].Name} Hp {GameManager.Stage.monsters[i].Health}");
                        }
                    }

                    catch { } // 예외처리
                }

                Console.ResetColor();

                Console.WriteLine("\n\n[내정보]\n");

                Console.Write("Lv. " + GameManager.player.level);
                Console.Write("  " + GameManager.player.playerName + " " + "(" + GameManager.player.playerJob + ")" + "\n"); //  job "전사" 로 고정되어있음

                Console.WriteLine("Hp " + $"{GameManager.player.playerCurHealth}" + "/" + $"{GameManager.player.playerMaxHealth}" + "\n");

                Console.WriteLine("대상을 선택해주세요.\n");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                Random random = new Random();

                int atkdamage = random.Next(GameManager.player.playerAttack - GameManager.player.playerAttack / 10, (GameManager.player.playerAttack + GameManager.player.playerAttack / 10) + 1);

                // 공격력 10% +- 오차범위 랜덤

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1: // 1번 몹 선택시

                        if (!GameManager.Stage.monsters[0].IsDead)
                        {
                            Console.Clear();

                            int mobCurHealth = GameManager.Stage.monsters[0].Health; 

                            Console.WriteLine(GameManager.player.playerName + "의 공격!");

                            GameManager.Stage.monsters[0].Health -= 5 * atkdamage; // 테스트용 공격력 수정할것

                            Console.WriteLine($"Lv.{GameManager.Stage.monsters[0].Level} {GameManager.Stage.monsters[0].Name} 을(를) 맞췄습니다. [데미지 : " + atkdamage + "]");

                            if (GameManager.Stage.monsters[0].Health > 0)
                            {
                                Console.WriteLine("Hp " + mobCurHealth + " -> " + $"{GameManager.Stage.monsters[0].Health}\n\n");

                                int playerCurHealth = GameManager.player.playerCurHealth; 

                                Thread.Sleep(500);

                                Console.WriteLine($"Lv.{GameManager.Stage.monsters[0].Level} {GameManager.Stage.monsters[0].Name} 의 공격!");

                                Console.WriteLine(GameManager.player.playerName + "을(를) 맞췄습니다. [데미지 : " + GameManager.Stage.monsters[0].Attack + "]");

                                GameManager.player.playerCurHealth -= GameManager.Stage.monsters[0].Attack;

                                Console.Write("Lv. " + GameManager.player.level + " " + GameManager.player.playerName);

                                Console.WriteLine("Hp " + playerCurHealth + " -> " + $"{GameManager.player.playerCurHealth}\n");

                                Thread.Sleep(500);
                            }
                            else
                            {
                                Console.WriteLine("Hp " + mobCurHealth + " -> " + "Dead\n\n");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("올바른 대상을 지정해주세요.\n");
                            Console.ResetColor();
                            continue;
                        }

                        break;

                    case ConsoleKey.D2: // 2번 몹 선택시

                        try
                        {
                            if (!GameManager.Stage.monsters[1].IsDead)
                            {
                                Console.Clear();

                                int mobCurHealth = GameManager.Stage.monsters[1].Health; 

                                Console.WriteLine(GameManager.player.playerName + "의 공격!");

                                GameManager.Stage.monsters[1].Health -= 5 * atkdamage; // 테스트용 공격력 수정할것

                                Console.WriteLine($"Lv.{GameManager.Stage.monsters[1].Level} {GameManager.Stage.monsters[1].Name} 을(를) 맞췄습니다. [데미지 : " + atkdamage + "]");

                                if (GameManager.Stage.monsters[1].Health > 0)
                                {
                                    Console.WriteLine("Hp " + mobCurHealth + " -> " + $"{GameManager.Stage.monsters[1].Health}\n\n");

                                    int playerCurHealth = GameManager.player.playerCurHealth; 

                                    Thread.Sleep(500);

                                    Console.WriteLine($"Lv.{GameManager.Stage.monsters[1].Level} {GameManager.Stage.monsters[1].Name} 의 공격!");

                                    Console.WriteLine(GameManager.player.playerName + "을(를) 맞췄습니다. [데미지 : " + GameManager.Stage.monsters[1].Attack + "]");

                                    GameManager.player.playerCurHealth -= GameManager.Stage.monsters[1].Attack;

                                    Console.Write("Lv. " + GameManager.player.level + " " + GameManager.player.playerName);

                                    Console.WriteLine("Hp " + playerCurHealth + " -> " + $"{GameManager.player.playerCurHealth}\n");

                                    Thread.Sleep(500);

                                }
                                else
                                {
                                    Console.WriteLine("Hp " + mobCurHealth + " -> " + "Dead\n\n");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("올바른 대상을 지정해주세요.\n");
                                Console.ResetColor();
                                continue;
                            }
                        }

                        catch { }

                        break;

                    case ConsoleKey.D3: // 3번 몹 선택시

                        try
                        {
                            if (!GameManager.Stage.monsters[2].IsDead)
                            {
                                Console.Clear();

                                int mobCurHealth = GameManager.Stage.monsters[2].Health; 

                                Console.WriteLine(GameManager.player.playerName + "의 공격!");

                                GameManager.Stage.monsters[2].Health -= 5 * atkdamage; // 테스트용 공격력 수정할것

                                Console.WriteLine($"Lv.{GameManager.Stage.monsters[2].Level} {GameManager.Stage.monsters[2].Name} 을(를) 맞췄습니다. [데미지 : " + atkdamage + "]");

                                if (GameManager.Stage.monsters[2].Health > 0)
                                {
                                    Console.WriteLine("Hp " + mobCurHealth + " -> " + $"{GameManager.Stage.monsters[2].Health}\n\n");

                                    int playerCurHealth = GameManager.player.playerCurHealth; 

                                    Thread.Sleep(500);

                                    Console.WriteLine($"Lv.{GameManager.Stage.monsters[2].Level} {GameManager.Stage.monsters[0].Name} 의 공격!");

                                    Console.WriteLine(GameManager.player.playerName + "을(를) 맞췄습니다. [데미지 : " + GameManager.Stage.monsters[2].Attack + "]");

                                    GameManager.player.playerCurHealth -= GameManager.Stage.monsters[2].Attack;

                                    Console.Write("Lv. " + GameManager.player.level + " " + GameManager.player.playerName);

                                    Console.WriteLine("Hp " + playerCurHealth + " -> " + $"{GameManager.player.playerCurHealth}\n");

                                    Thread.Sleep(500);
                                }
                                else
                                {
                                    Console.WriteLine("Hp " + mobCurHealth + " -> " + "Dead\n\n");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("올바른 대상을 지정해주세요.\n");
                                Console.ResetColor();
                                continue;
                            }
                        }

                        catch { }

                        break;

                    default: // 그 외
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("올바른 대상을 지정해주세요.\n");
                        Console.ResetColor();
                        continue;

                }

                continue;

            }

        }
    }
}
