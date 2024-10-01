using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG.Scene
{
    public class StoreScene : BaseScene
    {
        public override void Load()
        {
            Console.WriteLine("상점에 오신 것을 환영합니다.");

            ChooseStore();

            //GameManager.Event.Dispatch(GameEventType.BuyItem, new BuyItemEventArgs()
            //{
            //    Name = "강철검",
            //    Count = 1
            //});
        }

        public void ChooseStore()
        {
            int input = Input.Selection(1, "무기 상점", "방어구 상점", "나가기");

            if (input == 1)
            {
                GameManager.Scene.OpenScene(SceneType.StoreWeapon);
            }
            else if (input == 2)
            {
                GameManager.Scene.OpenScene(SceneType.StoreArmor);
            }
            else if (input == 3) 
            {
                GameManager.Scene.CloseScene();
            }

        }
    }          
}

