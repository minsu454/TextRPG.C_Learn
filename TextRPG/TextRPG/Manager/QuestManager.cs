namespace TextRPG
{
    public class QuestManager
    {
        public Dictionary<QuestNameType, BaseQuest> questDic {  get; private set; } = new Dictionary<QuestNameType, BaseQuest>();

        public void Init()
        {
            foreach (QuestNameType type in Enum.GetValues(typeof(QuestNameType)))
            {
                BaseQuest? quest = QuestFactory.CreateQuest(type);

                if (quest == null)
                    continue;

                quest.Init();
                questDic.Add(type, quest);
            }
        }
    }
}
