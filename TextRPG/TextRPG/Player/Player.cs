using System.Xml.Linq;

namespace TextRPG
{

    public class Player
    {
        public string playerName { get; set; }
        public string playerJob { get; set; }

        public int playerAttack { get; set; }
        public int playerDefense { get; set; }
        public int playerCurHealth { get; set; }
        public int playerMaxHealth { get; set; }

        public int playerGold { get; set; }

        public Player(string name, string job, int attack, int defense, int curHealth, int maxHealth, int gold)
        {
            playerName = name;
            playerJob = job;
            playerAttack = attack;
            playerDefense = defense;
            playerCurHealth = curHealth;
            playerMaxHealth = maxHealth;
            playerGold = gold;
        }
        public Player()
        {

        }

        public void ShowJobDetails() 
        {
            Console.WriteLine($"\n이름: {playerName}\n직업: {playerJob}\n공격력: {playerAttack}\n방어력: {playerDefense}\n체력: {playerCurHealth}/{playerMaxHealth}\n소지금: {playerGold}G");
        }
    }
}

