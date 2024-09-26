namespace TextRPG
{
    /// <summary>
    /// 플레이어 스텟관련 퀘스트 인터페이스 
    /// </summary>
    public interface IQuestPlayerStat
    {
        public bool Check(string statName);
        public bool Check(string statName, int stat);
    }
}
