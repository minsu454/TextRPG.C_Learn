namespace TextRPG
{
    public abstract class BaseQuest
    {
        public QuestType type;

        public string? name;
        public string? comment;

        public string? pay;

        public List<int> payList = new List<int>();

        public BaseQuest() { Init(); }

        public virtual void Init() {
            
        }
    }
}
