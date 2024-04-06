using _Game.Script.GamePlay.Map;
using _Game.Script.Level;
using _Game.Script.UserData;
using UnityEngine;

namespace _Game.Script.Manager
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private LevelDataSO levelDataSO;
        [SerializeField] private MapDataSO mapDataSO;
        
        private Level.Level currentLevel;
        private Map currentMap;
        
        public void LoadMap(int index)
        {
            DespawnMap();
            currentLevel = levelDataSO.GetLevel(index);
            currentMap = Instantiate(mapDataSO.Map(currentLevel.MapId));
        }
        
        public void LoadMap()
        {
            LoadMap(DataManager.Ins.GetUserDataLevel());
        }
        
        public void LoadNextMap()
        {
            DataManager.Ins.SetUserDataLevel(DataManager.Ins.GetUserDataLevel() + 1);
            LoadMap(DataManager.Ins.GetUserDataLevel());
        }
        
        public void DespawnMap()
        {
            if (currentMap != null)
            {
                Destroy(currentMap.gameObject);
            }
        }
        
        public int NumberOfBots => currentLevel.NumberOfBots;
    }
}