namespace TextRPG
{
    public abstract class BaseQuest
    {
        private QuestStateType _state;
        public QuestStateType State
        {
            get { return _state; }
            set
            {
                if (_state == value)
                {
                    return;
                }
                _state = value;
                stateChanged.Invoke(this, value);
            }
        }
        public QuestType Type { get; init; }

        public virtual string Name { get; }
        public virtual string Comment { get; }
        public virtual string Reward { get; }

        public List<int> payList = new List<int>();

        public abstract void Init();
        public abstract void Release();

        public event Action<BaseQuest, QuestStateType> stateChanged;
    }
}
