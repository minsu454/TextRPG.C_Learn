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
            Console.Clear();
            Console.WriteLine("�� ����");
            Console.WriteLine("\n1. ö����\n2. �κ�\n3. õ��\n4. ����\n5. ������\n");

            ChooseWeapon();

        }

        public void ChooseWeapon()
        {
            int input = Input.InputKey(5);

            Console.WriteLine("\n�����Ͻðڽ��ϱ�?");
            {                
                if (input == 1)
                {
                    Buyitem();
                }                
                else if (input == 2)
                {
                    Buyitem();
                }
                else if (input == 3)
                {
                    Buyitem();
                }
                else if (input == 4)
                {
                    Buyitem();
                }
                else if (input == 5)
                {
                    GameManager.Scene.CloseScene();
                }
            }
        }
        public void Buyitem()
        {
            int input = Input.Selection(1, "��", "�ƴϿ�");
            if (input == 1)
            {
                Console.WriteLine("\n���Ű� �Ϸ�Ǿ����ϴ�.");
                //GameManager.player.List<Item> = add();
            }
            else if (input == 2)
            {
                Console.WriteLine("\n���Ÿ� ����Ͽ����ϴ�.");
            }
        }
    }
}