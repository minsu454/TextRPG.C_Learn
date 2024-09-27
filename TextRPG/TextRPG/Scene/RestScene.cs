namespace TextRPG
{
    public class RestScene : BaseScene                               
    {
        //1. 휴식 씬에 들어오면 "휴식하시겠습니까?" 문구가 나오고 "1. 예" 문구와 "2. 아니오." 문구가 나온다.
        //2. "예"(숫자키 1)를 선택 시 체력이 충전되고 "체력이 충전되었습니다." 문구가 나온다. 그 후 로비로 돌아온다.
        //3. "아니오"(숫자키 2)를 선택 시 바로 로비로 돌아온다.
        //4. 숫자키 1, 2 이외의 다른 키를 누르면 반응이 없다.

        //필요한 기능
        //현재 체력은 최신화 되어야 한다?
        //던전 입장 후 중간에 로비로 돌아오고 그 다음에 휴식 공간 입장 가능?
        //전투 후 몬스터 혹은 기타 상황에 의해 깎인 체력 데이터?

        public override void Load()
        {
            {   

                Console.WriteLine($"현재 체력: {GameManager.player.playerCurHealth}");  //플레이어의 현재 체력
                Console.WriteLine("휴식하시겠습니까?");

                ChooseChoice();
                                
                GameManager.Scene.CloseScene();                
            }                       
        }
        public void ChooseChoice()
        {
                        
                Console.WriteLine("예.");
                Console.WriteLine("아니오.");

                // ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                int input = Input.InputKey(2);

                //if (keyInfo.Key == ConsoleKey.D1) //딜레이를 걸 것인지 "로비 화면으로 넘어가시겠습니까" 선택 UI를 만들 것인지
                //{
                //    validSelection = true;
                //    Console.WriteLine("현재 체력: "); //플레이어의 현재 체력
                //    Console.WriteLine("체력이 충전되었습니다.");
                //    //로비 화면으로 넘어간다.

                //}
                //else if(keyInfo.Key == ConsoleKey.D2)
                //{
                //    validSelection = true;
                //    //로비 화면으로 넘어간다.
                //}
                //else
                //{
                //    //default: 아무 동작도 하지 않음
                //}

                if (input == 1)
                {                     
                    GameManager.player.playerCurHealth = GameManager.player.playerMaxHealth;
                }
                                
                    
    }

        

    }

}