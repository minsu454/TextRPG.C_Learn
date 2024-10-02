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
            //Console.Clear();
            Console.WriteLine("무기 상점");
            Console.WriteLine("\n1. 강철검\n2. 나무스태프\n3. 목궁\n4. 수리검\n5. 나가기\n");

            ChooseWeapon();

        }
        
        public void ChooseWeapon() 
        {
            int input = Input.InputKey(5);

            Console.WriteLine("\n\n구매하시겠습니까?\n");
            {
                if (input == 1)
                {
                    Buyitem(0);
                }
                else if (input == 2)
                {
                    Buyitem(1);
                }
                else if (input == 3)
                {
                    Buyitem(2);
                }
                else if (input == 4)
                {
                    Buyitem(3);
                }
                else if (input == 5)
                {
                    GameManager.Scene.CloseScene();
                }
            }
        }
        public void Buyitem(int index) 
        {
            int input = Input.Selection(1, "예", "아니오");
            if (input == 1)
            {
                Weapon weapon = GameManager.weapondb[index];
                if (GameManager.player.playerGold >= GameManager.weapon.WeaponPrice)
                {
                    if (GameManager.player.playerJob == GameManager.weapon.AbleJob)
                    {
                        
                        Console.WriteLine("\n\n" + weapon + " 구매가 완료되었습니다.");
                    }
                    else 
                    {
                        Console.WriteLine("\n\n구매할 수 없습니다.");
                    }
                   
                }
                else 
                {
                    Console.WriteLine("\n\n구매할 수 없습니다.");
                }

                Thread.Sleep(500);
            }
            else if (input == 2)
            {
                Console.WriteLine("\n\n구매를 취소하였습니다.");
                Thread.Sleep(500);
            }
        }
    }
}
