namespace TextRPG
{
    /// <summary>
    /// 퀘스트 상태 타입
    /// </summary>
    public enum QuestStateType
    {
        None = 0,           //퀘스트 수락 전
        Doing = 1,          //퀘스트 받음
        Completed = 2,      //깼음
        Rewarded = 3,       //보상받음

    }
}