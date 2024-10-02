using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    public class StoreScene_Armor : BaseScene
    {
        public List<string> itemlist = new List<string>();

        public override void Load()
        {
            //Console.Clear();
            Console.WriteLine("방어구 상점");
            Console.WriteLine("\n1. 철갑옷\n2. 로브\n3. 천옷\n4. 도복\n5. 나가기\n");

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
                Armor armor = GameManager.armordb[index];
                if (GameManager.player.playerGold >= GameManager.armor.ArmorPrice)
                {
                    if (GameManager.player.playerJob == GameManager.armor.AbleJob)
                    {
                        
                        Console.WriteLine("\n\n" + armor + " 구매가 완료되었습니다."); // 구매 조건이 충족되면 아이템이 구매되고 인벤토리로 간다. // + + 안에 아이템 이름이 들어간다.
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
                Console.WriteLine("\n구매를 취소하였습니다.");
                Thread.Sleep(500);
            }
        }
    }
}