using System.Numerics;
using System.Reflection.Emit;
using System.Text;

namespace TextRPG
{
    public class DungeonScene : BaseScene, IMainScene
    {
        private int shiftCount;

        public override void Load()
        {

            GameManager.Scene.OpenScene(SceneType.Lobby);
        }
    }

}
