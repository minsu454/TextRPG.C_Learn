using TextRPG.Scene;

namespace TextRPG
{
    public static class SceneFactory
    {
        /// <summary>
        /// 씬 생성자 리턴해주는 함수
        /// </summary>
        public static BaseScene? CreateScene(SceneType type)
        {
            BaseScene? scene = null;
            switch (type)
            {
                case SceneType.Start:
                    scene = new StartScene();
                    break;
                case SceneType.Lobby:
                    scene = new LobbyScene();
                    break;
                case SceneType.PlayerInfo:
                    scene = new PlayerInfoScene();
                    break;
                case SceneType.Inventory:
                    scene = new InventoryScene();
                    break;
                case SceneType.Store:
                    scene = new StoreScene();
                    break;
                case SceneType.Dungeon:
                    scene = new DungeonScene();
                    break;
                case SceneType.Rest:
                    scene = new RestScene();
                    break;
                case SceneType.Quest:
                    scene = new QuestScene();
                    break;
                case SceneType.Gambling:
                    scene = new GamblingScene();
                    break;
                case SceneType.Save:
                    scene = new SaveScene();
                    break;
                case SceneType.StoreWeapon:
                    scene = new StoreScene_Weapon();
                    break;
                case SceneType.StoreArmor:
                    scene = new StoreScene_Armor();
                    break;
                default:
                    break;
            }
            return scene;
        }
    }
}
