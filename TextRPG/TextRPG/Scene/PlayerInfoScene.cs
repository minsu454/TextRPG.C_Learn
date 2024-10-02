using System.Text;

namespace TextRPG
{
    public class PlayerInfoScene : BaseScene
    {
        private Player player;
        public override void Load()
        {
            player = GameManager.player;

            PlayerState();

            int input = Input.Selection(1, "스킬 설명 보러가기", "돌아가기");

            Console.Clear();

            if (input == 1)
                SkillState();

                GameManager.Scene.CloseScene();
        }

        private void PlayerState()
        {
            Print.ColorPrintScreen(ConsoleColor.Magenta, $"플레이어 상태창\n");
            Console.WriteLine($"이름: {player.playerName}");
            Console.WriteLine($"레벨: {player.level}");
            Console.WriteLine($"경험치: {player.playerCurExp}/{player.playerMaxExp}");
            Console.WriteLine($"직업: {player.playerJob}");
            Console.WriteLine($"공격력: {player.playerAttack}");
            Console.WriteLine($"방어력: {player.playerDefense}");
            Console.WriteLine($"체력: {player.playerCurHealth}/{player.playerMaxHealth}");
            Console.WriteLine($"마나: {player.playerCurMp}/{player.playerMaxMp}");
            Console.WriteLine($"소지금: {player.playerGold}G");
            Console.WriteLine("=========================");
        }

        private void SkillState()
        {
            var skill = player.Skill();
            Print.ColorPrintScreen(ConsoleColor.Magenta, $"스킬 상태창\n");

            for (int i = 0; i < skill.Count; i++)
            {
                Print.ColorPrintScreen(ConsoleColor.DarkGray, $"{i + 1}. {skill[i].Name}");
                Console.WriteLine($"{skill[i].Comment}\n");
            }


            Console.WriteLine();
            Input.Selection(1, "돌아가기");
        }
    }
}

