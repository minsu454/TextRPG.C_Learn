using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    public class StoreScene_Weapon : BaseScene
    {
        public override void Load()
        {
            Console.Clear();
            Console.WriteLine("무기 상점");
            Console.WriteLine("\n1. 강철검\n2. 나무스태프\n3. 목궁\n4. 수리검\n5. 나가기\n");

            ChooseWeapon();

        }

        public void ChooseWeapon() 
        {
            int input = Input.InputKey(5);

            {
                Console.WriteLine("\n구매하시겠습니까?");
                if (input == 1)
                {
                    input = Input.Selection(1, "예", "아니오");
                    if (input == 1)
                    {
                        Console.WriteLine("\n구매가 완료되었습니다.");
                        //GameManager.Item.ItemEquip = true;
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("\n구매를 취소하였습니다.");
                    }

                }
                if (input == 2)
                {
                    Input.Selection(1, "예", "아니오");
                    if (input == 1)
                    {
                        Console.WriteLine("\n구매가 완료되었습니다.");
                        //GameManager.Item.ItemEquip = true;
                    }
                    else if (input == 2)
                    {

                    }

                }
                if (input == 3)
                {
                    Input.Selection(1, "예", "아니오");
                    if (input == 1)
                    {
                        Console.WriteLine("\n구매가 완료되었습니다.");
                        //GameManager.Item.ItemEquip = true;
                    }
                    else if (input == 2)
                    {

                    }

                }
                if (input == 4)
                {
                    Input.Selection(1, "예", "아니오");
                    if (input == 1)
                    {
                        Console.WriteLine("\n구매가 완료되었습니다.");
                        //GameManager.Item.ItemEquip = true;
                    }
                    else if (input == 2)
                    {

                    }

                }
                else if(input == 5)
                {
                    GameManager.Scene.CloseScene();
                }
            }
            Thread.Sleep(500);
        }
    }
}
