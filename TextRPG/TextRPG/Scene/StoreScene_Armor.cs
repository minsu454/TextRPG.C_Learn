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
            Console.WriteLine("�� ����");
            Console.WriteLine("\n1. ö����\n2. �κ�\n3. õ��\n4. ����\n5. ������\n");

            ChooseWeapon();

        }

        public void ChooseWeapon()
        {
            int input = Input.InputKey(5);

            Console.WriteLine("\n\n�����Ͻðڽ��ϱ�?\n");
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
            int input = Input.Selection(1, "��", "�ƴϿ�");
            if (input == 1)
            {
                Armor armor = GameManager.armordb[index];
                if (GameManager.player.playerGold >= GameManager.armor.ArmorPrice)
                {
                    if (GameManager.player.playerJob == GameManager.armor.AbleJob)
                    {
                        
                        Console.WriteLine("\n\n" + armor + " ���Ű� �Ϸ�Ǿ����ϴ�."); // ���� ������ �����Ǹ� �������� ���ŵǰ� �κ��丮�� ����. // + + �ȿ� ������ �̸��� ����.
                    }
                    else
                    {
                        Console.WriteLine("\n\n������ �� �����ϴ�.");
                    }
                }
                else
                {
                    Console.WriteLine("\n\n������ �� �����ϴ�.");
                }
                Thread.Sleep(500);
            }
            else if (input == 2)
            {
                Console.WriteLine("\n���Ÿ� ����Ͽ����ϴ�.");
                Thread.Sleep(500);
            }
        }
    }
}