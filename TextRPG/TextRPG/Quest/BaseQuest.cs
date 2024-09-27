namespace TextRPG
{
    public enum QuestState
    {
        None = 0,           //아직안깸
        Completed = 1,      //깼음
        Rewarded = 2,       //보상받음

    }

    public abstract class BaseQuest
    {
        public QuestType type;
        public QuestState state;

        public string? name;
        public string? comment;

        public string? pay;

        public List<int> payList = new List<int>();

        public abstract void Init();
        public abstract void Release();
    }
}
