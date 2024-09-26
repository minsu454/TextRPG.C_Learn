using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG
{
    public class StoreScene : BaseScene
    {
        public override void Load()
        {
            GameManager.Event.Dispatch(GameEventType.BuyItem, new BuyItemEventArgs()
            {
                Name = "무기", Count = 1
            });

            GameManager.Scene.CloseScene();
        }
    }
}
