using System.Text;

namespace TextRPG
{
    public class RestScene : BaseScene
    {
        public override void Load()
        {

            GameManager.player.playerCurHealth = GameManager.player.playerMaxHealth;

            GameManager.Scene.CloseScene();
        }

        #region PrintFormat

        #endregion

    }

}