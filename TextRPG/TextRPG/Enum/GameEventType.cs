namespace TextRPG
{
    public enum GameEventType
    {
        None = 0,       
        BuyItem = 1,    //아이템 살때 호출
        KillEnemy = 2,  //적을 잡았을 때 호출
        Rest = 3,       //휴식
    }
}
