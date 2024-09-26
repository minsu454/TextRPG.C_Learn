namespace TextRPG
{
    public class QuestManager
    {
        public Dictionary<QuestNameType, BaseQuest> questDic {  get; private set; } = new Dictionary<QuestNameType, BaseQuest>();

        public void Init()
        {
            foreach (QuestNameType type in Enum.GetValues(typeof(QuestNameType)))
            {
                BaseQuest? scene = QuestFactory.CreateQuest(type);

                if (scene == null)
                    continue;

                questDic.Add(type, scene);
            }
        }

        public void Check(QuestNameType type)
        {
            BaseQuest quest = questDic[type];

            switch (quest.type)
            {
                case QuestType.PlayerStat:
                    { 
                        IQuestPlayerStat? q = quest as IQuestPlayerStat;

                        if (q != null)
                            return;

                        q.Check("방패");
                    }
                    break;
                case QuestType.Dungeon:
                    break;
            }
        }
    }
}
