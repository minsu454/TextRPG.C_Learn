using System.Text;

namespace TextRPG
{
    public class PlayerInfoScene : BaseScene
    {
        public override void Load()
        {
            
            Console.Clear();
            Console.WriteLine("플레이어 상태창");
            Console.WriteLine($"이름: {GameManager.player.playerName}");
            Console.WriteLine($"레벨: {GameManager.player.level}");
            Console.WriteLine($"경험치: {GameManager.player.playerCurExp}/{GameManager.player.playerMaxExp}");
            Console.WriteLine($"직업: {GameManager.player.playerJob}");
            Console.WriteLine($"공격력: {GameManager.player.playerAttack}");
            Console.WriteLine($"방어력: {GameManager.player.playerDefense}");
            Console.WriteLine($"체력: {GameManager.player.playerCurHealth}/{GameManager.player.playerMaxHealth}");
            Console.WriteLine($"소지금: {GameManager.player.playerGold}G");
            Console.WriteLine("=========================");

            Console.WriteLine("아무키나 누르면 로비로 이동합니다.");
            Console.ReadKey(true);
            GameManager.Scene.CloseScene(); 
        }
        

        #region PrintFormat

        #endregion
    }
}

