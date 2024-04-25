using System.IO;
using _Game.Script.DataSO.ItemData;
using _Game.Script.GamePlay.Character.Player;
using _Game.Script.OtherOpti;
using Newtonsoft.Json;
using UnityEngine;

namespace _Game.Script.UserData
{
    public class DataManager : Singleton<DataManager>
    {
        [SerializeField] private UserData userData;
        
        //public UserData UserData => userData;

        private void Awake()
        {
            LoadUserData();
        }

        [ContextMenu("DeleteData")]
        private void DeleteData()
        {
            PlayerPrefs.DeleteAll();
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
            string json = JsonConvert.SerializeObject(userData);
            PlayerPrefs.SetString(Constances.Data.UserData, json);
        }

        private void LoadUserData()
        {
            string json = PlayerPrefs.GetString(Constances.Data.UserData);
            userData = JsonConvert.DeserializeObject<UserData>(json);
        }
        
        public int GetItemState(ItemDataSOManager.ItemTypeEnum itemType, int itemIds)
        {
            return userData.GetItemState(itemType, itemIds);
        }
        
        public int? GetItemEquipped(ItemDataSOManager.ItemTypeEnum itemType)
        {
            return userData.GetItemEquipped(itemType);
        }
        
        public bool GetVibrator()
        {
            return userData.Vibrator;
        }
        
        public void SetVibrator(bool value)
        {
            userData.Vibrator = value;
        }
        
        public bool GetSound()
        {
            return userData.Sound;
        }
        
        public void SetSound(bool value)
        {
            userData.Sound = value;
        }
        
    }
}