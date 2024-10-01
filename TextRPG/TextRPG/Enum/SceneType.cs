namespace TextRPG
{
    /// <summary>
    /// 씬타입
    /// </summary>
    public enum SceneType
    {
        None = 0,
        Start = 1,          //시작화면
        Lobby = 2,          //로비화면
        PlayerInfo = 3,     //플레이어정보
        Inventory = 4,      //인벤토리
        Store = 5,          //상점
        Quest = 6,          //퀘스트
        Dungeon = 7,        //던전
        Rest = 8,           //휴식
        Save = 9,           //저장
        StoreWeapon = 10,
        StoreArmor = 11,
    }
}
