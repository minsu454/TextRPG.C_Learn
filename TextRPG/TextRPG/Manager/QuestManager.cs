namespace TextRPG
{
    public class QuestManager
    {
        private readonly Dictionary<QuestNameType, BaseQuest> questDic = new Dictionary<QuestNameType, BaseQuest>();        //모든 퀘스트 저장하는 dictionary
        public Dictionary<QuestNameType, BaseQuest> QuestDic {  get { return questDic; } }

        public void Init()
        {
            foreach (QuestNameType type in Enum.GetValues(typeof(QuestNameType)))
            {
                if (type == QuestNameType.None)
                    continue;

                AddQuest(type);
            }
        }

        /// <summary>
        /// 퀘스트 이벤트 구독해주는 함수
        /// </summary>
        public void AddQuest(QuestNameType questType)
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
                quest.Release();
            }
            else if (state == QuestStateType.Rewarded)
            {
                quest.GiveReward();
            }
        }

        /// <summary>
        /// 퀘스트 이벤트 지워주는 함수
        /// </summary>
        private void RemoveQuest(QuestNameType questType)
        {
            if (questDic.Remove(questType, out var quest))
            {
                quest.stateChanged -= Quest_stateChanged;
                quest.Release();
            }
        }

        /// <summary>
        /// 퀘스트 이벤트 지워주는 함수
        /// </summary>
        private void ResetQuest(QuestNameType questType)
        {
            if (questDic.ContainsKey(questType))
            {
                questDic[questType].Reset();
            }
        }
    }
}
