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
            Console.WriteLine("�� ����");
            Console.WriteLine("\n1. ö����\n2. �κ�\n3. õ��\n4. ����\n5. ������\n");

            ChooseWeapon();

        }

        public void ChooseWeapon()
        {
            int input = Input.InputKey(5);

            {
                Console.WriteLine("\n�����Ͻðڽ��ϱ�?");
                if (input == 1)
                {
                    Input.Selection(1, "��", "�ƴϿ�");
                    if (input == 1)
                    {
                        Console.WriteLine("\n���Ű� �Ϸ�Ǿ����ϴ�.");
                        //GameManager.Item.ItemEquip = true;
                    }
                    else if (input == 2) 
                    {

                    }

                }                
                if (input == 2)
                {
                    Input.Selection(1, "��", "�ƴϿ�");
                    if (input == 1)
                    {
                        Console.WriteLine("\n���Ű� �Ϸ�Ǿ����ϴ�.");
                        //GameManager.Item.ItemEquip = true;
                    }
                    else if (input == 2) 
                    {

                    }

                }if (input == 3)
                {
                    Input.Selection(1, "��", "�ƴϿ�");
                    if (input == 1)
                    {
                        Console.WriteLine("\n���Ű� �Ϸ�Ǿ����ϴ�.");
                        //GameManager.Item.ItemEquip = true;
                    }
                    else if (input == 2) 
                    {

                    }

                }if (input == 4)
                {
                    Input.Selection(1, "��", "�ƴϿ�");
                    if (input == 1)
                    {
                        Console.WriteLine("\n���Ű� �Ϸ�Ǿ����ϴ�.");
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