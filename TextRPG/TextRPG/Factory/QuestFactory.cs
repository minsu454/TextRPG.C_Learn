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
                case QuestType.BuyItem:
                    quest = new BuyItemQuest();
                    break;
                case QuestType.KillGoblin:
                    quest = new KillGoblinQuest();
                    break;
                case QuestType.KillOrk:
                    quest = new KillGoblinQuest();
                    break;
                case QuestType.Rest:
                    quest = new RestQuest();
                    break;
                case QuestType.StageClear:
                    quest = new BaseStageClearQuest();
                    break;
                default:
                    break;
            }
            return quest;
        }
    }
}
