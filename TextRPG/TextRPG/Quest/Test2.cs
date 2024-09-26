namespace TextRPG
{
    public class Test2 : BaseQuest, IQuestDungeon
    {
        public override void Init()
        {
            type = QuestType.Dungeon;
            name = "고블린";
            comment = "하나만 잡아보자";
            pay = "10000 G";
        }

        public virtual bool Check(string enemyName, int count)
        {
            return true;
        }
    }
}
