namespace TextRPG
{

    public class Player
    {
        public string playerName;
        public string playerJob;

        public int playerAttack;
        public int playerDefense;
        public int playerCurHealth;
        public int playerMaxHealth;

        public int playerGold;

        public Player()
        {
            this.playerName = "안녕";
            this.playerJob = "전사";
            this.playerAttack = 10;
            this.playerDefense = 1;
            this.playerCurHealth = 50;
            this.playerMaxHealth = 100;
            this.playerGold = 3000;
        }

        public Player(string playerName, string playerJob, int playerAttack, int playerDefense, int playerHealth, int playerGold)
        {
            this.playerName = playerName;
            this.playerJob = playerJob;
            this.playerAttack = playerAttack;
            this.playerDefense = playerDefense;
            this.playerCurHealth = playerHealth;
            this.playerMaxHealth = playerHealth;
            this.playerGold = playerGold;
        }
    }

  
}
