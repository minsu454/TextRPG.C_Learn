using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG
{
    public class StoreScene : BaseScene
    {
        // 상점에 오신 것을 환영합니다.

        // 1. 강철검
        // 2. 나무스태프
        // 3. 목궁
        // 4. 수리검
        // 1~4 선택 시 "구매하시겠습니까?" 메시지가 뜬다.
        // 1. 예
        // 2. 아니오
        // "예" 선택 시 "아이템이 구매되었습니다." 메세지와 함께 아이템이 장착된다.
        // "아니오" 선택 시 아무 행동도 하지 않는다.

        public override void Load()
        {
            Console.WriteLine("상점에 오신 것을 환영합니다.");

            ChooseItem();
            //ChooseChoice();

            //GameManager.Event.Dispatch(GameEventType.BuyItem, new BuyItemEventArgs()
            //{
            //    Name = "강철검", "나무스태프", "목궁", "수리검"
            //    Count = 1, 2, 3, 4

            //});

            GameManager.Scene.CloseScene();
        }

        public void ChooseItem()
        {
            int input = Input.InputKey(4); Input.Selection(1, "예", "아니오");
            
                Console.WriteLine("강철검\n나무스태프\n목궁\n수리검");

            {
                Console.WriteLine("구매하시겠습니까?");
                if (input == 1)
                {
                    Console.WriteLine("구매가 완료되었습니다.");
                    GameManager.Item.ItemEquip = true;
                }
            } 

            //switch (input) 
            //{
            //    case 1:
            //        Console.WriteLine();
            //        break;
            //    case 2:
            //        Console.WriteLine();
            //        break;
            //    case 3:
            //        Console.WriteLine();
            //        break;
            //    case 4:
            //        Console.WriteLine();
            //        break;
            //    default:
            //        Console.WriteLine("잘못된 입력입니다.");
            //        break;
            //}
        }

        //public void ChooseChoice()
        //    {
        //    int input = Input.Selection(1, "예", "아니오");
        //    {
        //        Console.WriteLine("구매하시겠습니까?");

        //        if (input == 1)
        //        {
        //            Console.WriteLine("구매가 완료되었습니다.");
        //            GameManager.Item.ItemEquip = true;
        //        }
        //    }
            
        //}        
    }
}
