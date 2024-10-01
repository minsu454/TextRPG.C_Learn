﻿namespace TextRPG
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
        public virtual QuestType QuestType { get; }

        public virtual string Name { get; }
        public virtual string Comment { get; }
        public virtual string Reward { get; }

        public List<int> payList = new List<int>();

        public abstract void Init();
        public abstract void Release();

        public bool IsOccult()
        {
            if (state == QuestStateType.Occult)
            {
                return true;
            }

            return false;
        }

        public event Action<BaseQuest, QuestStateType> stateChanged;
    }
}
