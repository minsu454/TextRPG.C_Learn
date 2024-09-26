using System;
using System.Text;

namespace TextRPG
{
    public class InventoryScene : BaseScene
    {
        /// <summary>
        /// 로딩 함수
        /// </summary>
        public override void Load()
        {

            //GameManager.Quest.Check(QuestNameType.Test1, new Test1QuestArgs());

            GameManager.Scene.CloseScene();

        }

        #region PrintFormat
        
        #endregion
    }
}
