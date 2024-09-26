namespace TextRPG
{
    public static class QuestFactory
    {
        /// <summary>
        /// 퀘스트 생성자 리턴해주는 함수
        /// </summary>
        public static BaseQuest? CreateQuest(QuestNameType type)
        {
            BaseQuest? quest = null;
            switch (type)
            {
                case QuestNameType.Test1:
                    quest = new Test1();
                    break;
                case QuestNameType.Test2:
                    quest = new Test2();
                    break;
                default:
                    break;
            }
            return quest;
        }
    }
}
