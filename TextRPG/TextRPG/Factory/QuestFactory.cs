namespace TextRPG
{
    public static class QuestFactory
    {
        /// <summary>
        /// 퀘스트 생성자 리턴해주는 함수
        /// </summary>
        public static BaseQuest CreateQuest(QuestNameType type)
        {
            BaseQuest quest = null;
            switch (type)
            {
                case QuestNameType.BuyItem:
                    quest = new BuyItemQuest();
                    break;
                case QuestNameType.KillGoblin:
                    quest = new KillGoblinQuest();
                    break;
                case QuestNameType.KillOrk:
                    quest = new KillOrkQuest();
                    break;
                case QuestNameType.Rest:
                    quest = new RestQuest();
                    break;
                default:
                    break;
            }
            return quest;
        }

        public static string GetQuestName(QuestStateType state)
        {
            string s = null;

            switch (state)
            {
                case QuestStateType.None:
                    s = "";
                    break;
                case QuestStateType.Doing:
                    s = "[진행중]";
                    break;
                case QuestStateType.Completed:
                    s = "[완료]";
                    break;
                case QuestStateType.Rewarded:
                    s = "[보상받음]";
                    break;
            }

            return s;
        }
    }
}
