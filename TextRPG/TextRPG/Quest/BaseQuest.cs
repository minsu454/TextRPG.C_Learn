namespace TextRPG
{
    public abstract class BaseQuest
    {
        public QuestStateType state;
        public GameEventType EventType { get; protected set; }

        public string? name;
        public string? comment;
        public string? pay;

        public List<int> payList = new List<int>();

        public abstract void Init();
        public abstract void Release();
        public abstract EventListener? listener();
    }
}
