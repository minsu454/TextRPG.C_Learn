namespace TextRPG
{
    /// <summary>
    /// 씬타입
    /// </summary>
    public enum SceneType
    {
        None = 0,
        Start = 1 << 0,         //시작화면
        Lobby = 1 << 1,         //로비화면
        PlayerInfo = 1 << 2,    //플레이어정보
        Inventory = 1 << 3,     //인벤토리
        Store = 1 << 4,         //상점
        Quest = 1 << 5,         //퀘스트
        Dungeon = 1 << 6,       //던전
        Rest = 1 << 7,          //휴식
    }
}
