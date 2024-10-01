namespace TextRPG
{
    /// <summary>
    /// 퀘스트 이름 타입
    /// </summary>
    public enum QuestType
    {
        None = 0,
        BuyItem = 1,        //아이템 살때 호출
        KillGoblin = 2,     //고블린 잡기
        KillOrk = 3,        //오크 잡기
        Rest = 4,           //휴식
        StageClear = 5,     //게임클리어
    }
}
