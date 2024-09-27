namespace TextRPG
{
    public class QuestManager
    {
        public Dictionary<QuestType, BaseQuest> questDic {  get; private set; } = new Dictionary<QuestType, BaseQuest>();

        public void Init()
        {
            foreach (QuestType type in Enum.GetValues(typeof(QuestType)))
            {
                BaseQuest? quest = QuestFactory.CreateQuest(type);

                if (quest == null)
                    continue;
                
                quest.Init();
                questDic.Add(type, quest);
            }
        }

        /// <summary>
        /// 퀘스트 이벤트 구독해주는 함수
        /// </summary>
        public void AddQuest(QuestType questType)
        {
            BaseQuest quest = questDic[questType];

            if (quest.state == QuestStateType.Completed)
            {
                return;
            }

            GameManager.Event.Subscribe(quest.EventType, quest.listener()!);
        }

        /// <summary>
        /// 퀘스트 이벤트 지워주는 함수
        /// </summary>
        public void RemoveQuest(QuestType questType)
        {
            BaseQuest quest = questDic[questType];

            if (quest.state != QuestStateType.Completed)
            {
                return;
            }

            GameManager.Event.Unsubscribe(quest.EventType, quest.listener()!);
        }
    }
}
