namespace TextRPG
{
    /// <summary>
    /// 이벤트 타입
    /// </summary>
    public enum GameEventType
    {
        None = 0,       
        BuyItem = 1,        //아이템 살때 호출
        KillMonster = 2,    //적을 잡았을 때 호출
        Rest = 3,           //휴식
        StageClear = 4,     //스테이지 클리어
    }
}
