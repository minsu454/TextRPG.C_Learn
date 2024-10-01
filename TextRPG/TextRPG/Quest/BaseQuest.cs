namespace TextRPG
{
    public abstract class BaseQuest
    {
        private QuestStateType state = QuestStateType.None;
        public QuestStateType State
        {
            get { return state; }
            set
            {
                if (state == value)
                {
                    return;
                }
                state = value;
                stateChanged.Invoke(this, value);
            }
        }
        public virtual QuestNameType QuestNameType { get; }

        public virtual string Name { get; }
        public virtual string Comment { get; }
        public virtual string Reward { get; }
        public virtual int CurCount { get; set; } = 0;
        public virtual int MaxCount { get; }

        protected List<int> rewardList = new List<int>();

        public abstract void Init();
        public abstract void Release();
        public abstract void GiveReward();

        public void Reset()
        {
            state = QuestStateType.None;
            CurCount = 0;
            Release();
        }

        public event Action<BaseQuest, QuestStateType> stateChanged;
    }
}
