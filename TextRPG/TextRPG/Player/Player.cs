using System.Reflection.Emit;
using System.Xml.Linq;

namespace TextRPG
{

    public class Player
    {
        public int level;
        public int StageNum;

        public string playerName { get; set; }
        public string playerJob { get; set; }

        public int playerAttack { get; set; }
        public int playerDefense { get; set; }
        public int playerCurHealth { get; set; }
        public int playerMaxHealth { get; set; }

        public int playerGold { get; set; }

        public List<(QuestNameType, QuestStateType, int)> questList = new List<(QuestNameType, QuestStateType, int)>();

        public Player(string name, string job, int attack, int defense, int maxHealth, int gold)
        {
            level = 1;
            StageNum = 1;
            playerName = name;
            playerJob = job;
            playerAttack = attack;
            playerDefense = defense;
            playerCurHealth = maxHealth;
            playerMaxHealth = maxHealth;
            playerGold = gold;
        }

        public void Save()
        {
            questList.Clear();
            var dic = GameManager.Quest.QuestDic;
            foreach (var kvp in dic)
            {
                if(kvp.Value.State != QuestStateType.None)
                    questList.Add(new (kvp.Key, kvp.Value.State, kvp.Value.CurCount));
            }

            GameManager.Save.Save(this);
        }

        public void Load()
        {
            var dic = GameManager.Quest.QuestDic;

            foreach (var kvp in questList)
            {
                dic[kvp.Item1].State = kvp.Item2;
                dic[kvp.Item1].CurCount = kvp.Item3;
            }
        }
    }
}

