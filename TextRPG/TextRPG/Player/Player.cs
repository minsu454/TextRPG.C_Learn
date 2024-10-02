using System.Reflection.Emit;
using System.Xml.Linq;

namespace TextRPG
{

    public class Player
    {
        public int level;
        public int StageNum;

        public string playerName;
        public string playerJob;

        public int playerAttack;  
        public int playerDefense;
        public int playerCurHealth;
        public int playerMaxHealth;
        public int playerCurExp;
        public int playerMaxExp;

        public int playerGold;

        public List<(QuestNameType, QuestStateType, int)> questList = new List<(QuestNameType, QuestStateType, int)>();

        public Player(string name, string job, int attack, int defense, int maxHealth, int maxExp, int gold)
        {
            level = 1;
            StageNum = 1;
            playerName = name;
            playerJob = job;
            playerAttack = attack;
            playerDefense = defense;
            playerCurHealth = maxHealth;
            playerMaxHealth = maxHealth;
            playerCurExp = 0;
            playerMaxExp = maxExp;
            playerGold = gold;
        }

        public void GetExp(int exp)
        {
            playerCurExp += exp;
            if (playerCurExp >= playerMaxExp)
            {
                playerCurExp -= playerMaxExp;
                LevelUp();
                SetMaxExp();
            }
        }

        public void LevelUp()
        {
            level++;
            switch (playerJob)
            {
                case "전사":
                    playerAttack += 2;
                    playerDefense += 4;
                    break;
                case "궁수":
                case "마법사":
                    playerAttack += 4;
                    playerDefense += 2;
                    break;
                case "도적":
                    playerAttack += 5;
                    playerDefense += 1;
                    break;
                default:
                    throw new NullReferenceException(playerJob);
            }
        }

        public void SetMaxExp()
        {
            playerMaxExp = playerMaxExp + (level * 10);
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

