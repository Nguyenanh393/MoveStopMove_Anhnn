using System.IO;
using _Game.Script.DataSO.ItemData;
using Newtonsoft.Json;
using UnityEngine;

namespace _Game.Script.UserData
{
    public class DataManager : Singleton<DataManager>
    {
        [SerializeField] private UserData userData;
        
        public UserData UserData => userData;

        private void Awake()
        {
            LoadUserData();
        }

        private void OnApplicationQuit()
        {
            SaveUserData();
        }
        
        public void SetUserDataLevel(int level)
        {
            userData.Level = level;
        }
        
        public void SetUserDataCoin(int coin)
        {
            userData.Coin = coin;
        }
        
        public void SetUserDataItemState(ItemDataSOManager.ItemTypeEnum itemType, int itemIds, int value)
        {
            userData.SetItemStates(itemType, itemIds, value);
        }
        
        public int GetUserDataLevel()
        {
            return userData.Level;
        }
        
        public int GetUserDataCoin()
        {
            return userData.Coin;
        }

        private void SaveUserData()
        {
            string json = JsonUtility.ToJson(userData);
            PlayerPrefs.SetString("UserData", json);
        }

        private void LoadUserData()
        {
            string json = PlayerPrefs.GetString("UserData");
            userData = JsonConvert.DeserializeObject<UserData>(json);
        }
        
        public int GetItemState(ItemDataSOManager.ItemTypeEnum itemType, int itemIds)
        {
            return userData.GetItemState(itemType, itemIds);
        }
        
    }
}