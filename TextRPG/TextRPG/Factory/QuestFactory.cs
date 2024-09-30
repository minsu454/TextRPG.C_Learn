namespace TextRPG
{
    public static class QuestFactory
    {
        /// <summary>
        /// 퀘스트 생성자 리턴해주는 함수
        /// </summary>
        public static BaseQuest CreateQuest(QuestType type)
        {
            BaseQuest quest = null;
            switch (type)
            {
                case QuestType.Test1:
                    quest = new Test1() { Type = QuestType.Test1 };
                    break;
                case QuestType.Test2:
                    quest = new Test2() { Type = QuestType.Test2 };
                    break;
                default:
                    break;
            }
            return quest;
        }
    }
}
