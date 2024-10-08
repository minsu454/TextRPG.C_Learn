﻿using System.Reflection.Emit;
using System.Xml.Linq;

namespace TextRPG
{

    public class Player
    {
        public int level;
        public int StageNum;

        public string playerName;
        public string playerJob;
        private BaseJobSkill skill;

        public int playerAttack;
        public int playerDefense;
        public int playerCurHealth;
        public int playerMaxHealth;
        public int playerCurMp;
        public int playerMaxMp;
        public int playerCurExp;
        public int playerMaxExp;

        public int playerGold;
        
        public int playerCritical;
        public int playerDodge;

        public List<(QuestNameType, QuestStateType, int)> questList = new List<(QuestNameType, QuestStateType, int)>();
        public List<string> itemlist = new List<string>();
        public List<Weapon> weapondb = new List<Weapon>();
        public List<Armor> armordb = new List<Armor> ();

        public Player()
        {

        }
        
        public Player(string name, string job, int attack, int defense, int maxHealth, int maxMana, int maxExp, int gold)
        {
            level = 1;
            StageNum = 1;
            playerCritical = 15;
            playerDodge = 10;
            playerName = name;
            playerJob = job;
            playerAttack = attack;
            playerDefense = defense;
            playerCurHealth = maxHealth;
            playerMaxHealth = maxHealth;
            playerCurMp = maxMana;
            playerMaxMp = maxMana;
            playerCurExp = 0;
            playerMaxExp = maxExp;
            playerGold = gold;
            skill = SkillFactory.CreateSkill(playerJob);
        }

        /// <summary>
        /// 플레이어가 경험치 얻는 함수
        /// </summary>
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

        /// <summary>
        /// 레벨업 함수
        /// </summary>
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

            Console.WriteLine("Level Up!!");
        }

        /// <summary>
        /// 최대 경험치 늘려주는 함수
        /// </summary>
        public void SetMaxExp()
        {
            playerMaxExp += 10;
        }

        /// <summary>
        /// 마나 채워주는 함수
        /// </summary>
        public void PlusMp(int mana)
        {
            if (playerMaxMp < playerCurMp + mana)
            {
                playerCurMp = playerMaxMp;
                return;
            }

            playerCurMp += mana;
        }

        /// <summary>
        /// 플레이어 세이브해주는 함수
        /// </summary>
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

        public List<ISkill> Skill()
        {
            return skill.SkillList;
        }

        /// <summary>
        /// 플레이어 데이터 로드해주는 함수
        /// </summary>
        public void Load()
        {
            var dic = GameManager.Quest.QuestDic;

            foreach (var kvp in questList)
            {
                dic[kvp.Item1].State = kvp.Item2;
                dic[kvp.Item1].CurCount = kvp.Item3;
            }

            skill = SkillFactory.CreateSkill(playerJob);
        }
    }
}

