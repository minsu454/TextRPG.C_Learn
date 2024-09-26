namespace TextRPG
{
    public class Test1 : BaseQuest, IQuestPlayerStat
    {

        public override void Init()
        {
            type = QuestType.PlayerStat;
            name = "무기구매";
            comment = "하나만 사보자";
            pay = "1000 G";
        }

        public bool Check(string statName)
        {
            return true;
        }

        public bool Check(string statName, int stat)
        {
            return true;
        }

    }
}
