namespace TextRPG
{
    public class QuestManager
    {
        private readonly Dictionary<QuestType, BaseQuest> questDic = new Dictionary<QuestType, BaseQuest>();
        public Dictionary<QuestType, BaseQuest> QuestDic {  get { return questDic; } }

        List<QuestType> questList = new List<QuestType>();

        /// <summary>
        /// 퀘스트 이벤트 구독해주는 함수
        /// </summary>
        public void AddQuest(QuestType questType)
        {
            if(questDic.ContainsKey(questType))
            {
                return;   
            }

            BaseQuest quest = QuestFactory.CreateQuest(questType);
            quest.Init();
            quest.stateChanged += Quest_stateChanged;
            questDic.Add(questType, quest);
        }

        /// <summary>
        /// QuestStateType타입이 변할 때 호출해주는 함수
        /// </summary>
        private void Quest_stateChanged(BaseQuest quest, QuestStateType state)
        {
            if (state == QuestStateType.Completed)
            {
                questList.Add(quest.Type);
            }
        }

        /// <summary>
        /// 퀘스트 이벤트 지워주는 함수
        /// </summary>
        private void RemoveQuest(QuestType questType)
        {
            if (questDic.Remove(questType, out var quest))
            {
                quest.stateChanged -= Quest_stateChanged;
                quest.Release();
            }
        }
    }
}
