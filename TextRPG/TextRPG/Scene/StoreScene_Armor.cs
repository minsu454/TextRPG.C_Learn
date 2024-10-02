using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    public class StoreScene_Armor : BaseScene
    {
        public List<string> Itemlist = new List<string>();

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
                    Buyitem("ö����");
                }                
                else if (input == 2)
                {
                    Buyitem("�κ�");
                }
                else if (input == 3)
                {
                    Buyitem("õ��");
                }
                else if (input == 4)
                {
                    Buyitem("����");
                }
                else if (input == 5)
                {
                    GameManager.Scene.CloseScene();
                }
            }
        }
        public void Buyitem(string itemname)
        {
            int input = Input.Selection(1, "��", "�ƴϿ�");
            if (input == 1)
            {
                Itemlist.Add(itemname);
                Console.WriteLine("\n\n" + itemname + " ���Ű� �Ϸ�Ǿ����ϴ�.");
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