namespace TextRPG
{
    public delegate void EventListener(object args);

    public class EventManager
    {
        // 이벤트 구독 list Dictonary
        private Dictionary<GameEventType, List<EventListener>> eventListenerDic = new Dictionary<GameEventType, List<EventListener>>();

        /// <summary>
        /// 이벤트 구독하는 함수
        /// </summary>
        public void Subscribe(GameEventType type, EventListener listener)
        {
            if (!eventListenerDic.TryGetValue(type, out var list))
            {
                list = new List<EventListener>();
                eventListenerDic[type] = list;
            }

            list.Add(listener);
        }

        /// <summary>
        /// 이벤트 구독 해제하는 함수
        /// </summary>
        public void Unsubscribe(GameEventType type, EventListener listener)
        {
            if (!eventListenerDic.TryGetValue(type, out var list))
            {
                return;
            }

            list.Remove(listener);
            if (list.Count == 0)
            {
                eventListenerDic.Remove(type);
            }
        }

        /// <summary>
        /// 이벤트 달성하면 보내주는 함수
        /// </summary>
        public void Dispatch(GameEventType type, object arg)
        {
            if (!eventListenerDic.TryGetValue(type, out var list))
            {
                return;
            }

            var temp = list.ToList();

            foreach (var listener in temp)
            {
                try
                {
                    listener.Invoke(arg);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
