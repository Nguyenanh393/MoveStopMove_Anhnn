using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using _Game.Script.DataSO.ItemData;
using UnityEngine;

namespace _Game.Script.UserData
{
    [Serializable]
    public class UserData
    {
        [SerializeField] private int level;
        [SerializeField] private int coin;
        
        [JsonProperty]
        private Dictionary<ItemDataSOManager.ItemTypeEnum, List<int>> _itemStates = new Dictionary<ItemDataSOManager.ItemTypeEnum, List<int>>()
        {
            {ItemDataSOManager.ItemTypeEnum.Weapon, new List<int>(){1,0,0}},
            {ItemDataSOManager.ItemTypeEnum.Hat, new List<int>(){0,0,0,0,0,0,0,0}},
            {ItemDataSOManager.ItemTypeEnum.Pant, new List<int>(){0,0,0,0,0,0,0,0,0}},
            {ItemDataSOManager.ItemTypeEnum.Shield, new List<int>(){0}},
            {ItemDataSOManager.ItemTypeEnum.SkinSet, new List<int>(){0,0}},
        };

        public int Level
        {
            get => level;
            set => level = value;
        }

        public int Coin
        {
            get => coin;
            set => coin = value;
        }

        public void SetItemStates(ItemDataSOManager.ItemTypeEnum itemType, int itemIds, int value)
        {
            _itemStates[itemType][itemIds] = value;
        }

        public int GetItemState(ItemDataSOManager.ItemTypeEnum itemType, int itemIds)
        {
            int id = Convert.ToInt32(itemIds);
            return _itemStates[itemType][id];
        }
    }
}