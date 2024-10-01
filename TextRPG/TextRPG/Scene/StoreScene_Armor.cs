using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    public class StoreScene_Armor : BaseScene
    {
        public override void Load()
        {
            Console.WriteLine("방어구 상점");
            Console.WriteLine("\n1. 철갑옷\n2. 로브\n3. 천옷\n4. 도복\n5. 나가기\n");

            ChooseWeapon();

        }

        public void ChooseWeapon()
        {
            int input = Input.InputKey(5);

            {
                Console.WriteLine("\n구매하시겠습니까?");
                if (input == 1)
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

                }if (input == 3)
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

                }if (input == 4)
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
                else if (input == 5)
                {
                    GameManager.Scene.CloseScene();
                }
            }
            Thread.Sleep(500);
        }
    }
}