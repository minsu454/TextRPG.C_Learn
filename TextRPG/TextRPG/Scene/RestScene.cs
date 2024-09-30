namespace TextRPG
{
    public class RestScene : BaseScene                               
    {

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