using _Game.Script.GamePlay.Map;
using _Game.Script.Level;
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
            if (PlayerPrefs.HasKey("Map") == false)
            {
                PlayerPrefs.SetInt("Map", 0);
            }
            LoadMap(PlayerPrefs.GetInt("Map"));
        }
        
        public void LoadNextMap()
        {
            PlayerPrefs.SetInt("Map", PlayerPrefs.GetInt("Map") + 1);
            LoadMap(PlayerPrefs.GetInt("Map") + 1);
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