using System.Text;
using System.Xml.Linq;

namespace TextRPG
{
    public class StartScene : BaseScene, IMainScene
    {
        private int shiftCount = 0;

        public override void Load()
        {

            GameManager.Scene.OpenScene(SceneType.Lobby);
        }
    }
}
