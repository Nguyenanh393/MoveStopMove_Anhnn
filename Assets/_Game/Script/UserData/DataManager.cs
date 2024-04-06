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

        private void Start()
        {
            LoadUserData();
        }

        private void OnApplicationQuit()
        {
            SaveUserData();
            ExportToJson();
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
            string json = File.ReadAllText("Assets/_Game/Script/UserData/userData.json");
            userData = JsonConvert.DeserializeObject<UserData>(json);
        }
        
        public int GetItemState(ItemDataSOManager.ItemTypeEnum itemType, int itemIds)
        {
            return userData.GetItemState(itemType, itemIds);
        }

        private void ExportToJson()
        {
            string json = JsonConvert.SerializeObject(userData);
            File.WriteAllText("Assets/_Game/Script/UserData/userData.json", json);
        }
    }
}