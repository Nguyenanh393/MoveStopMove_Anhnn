using System.Collections.Generic;
using _Game.Script.DataSO.ItemData;
using _UI.Scripts.UI.SkinShopButton;
using UnityEngine;

namespace _UI.Scripts.UI.ItemSkinShopButton
{
    public class ItemSelectionUI : Singleton<ItemSelectionUI>
    {
        [SerializeField] private ItemButtonUI itemButtonPrefab;
        [SerializeField] private Transform itemParent;
        [SerializeField] private TopBarButtonSO itemButtonSO;
        
        private List<ItemButtonUI> itemButtonHatList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonPantList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonShieldList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonSkinSetList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonList = new List<ItemButtonUI>();
        private void OnEnable()
        {
            SpawnAllItemButton();
            SpawnItemButtons(itemButtonHatList);
        }
        
        public List<ItemButtonUI> GetItemButtonList(ItemDataSOList.ItemTypeEnum itemType)
        {
            switch (itemType)
            {
                case ItemDataSOList.ItemTypeEnum.Hat:
                    return itemButtonHatList;
                case ItemDataSOList.ItemTypeEnum.Pant:
                    return itemButtonPantList;
                case ItemDataSOList.ItemTypeEnum.Shield:
                    return itemButtonShieldList;
                case ItemDataSOList.ItemTypeEnum.SkinSet:
                    return itemButtonSkinSetList;
                default:
                    return null;
            }
        }

        public void SpawnItemButtons(List<ItemButtonUI> itemButtonList)
        {
            for (int i = 0; i < itemButtonList.Count; i++)
            {
                itemButtonList[i].gameObject.SetActive(true);
            }
        }

        private void SpawnAllItemButton()
        {
            for (int i = 0; i < ItemDataSOList.Ins.HatSO.DataList.Count; i++)
            {
                SpawnItemButton(ItemDataSOList.Ins.HatSO.DataList[i].GetTypeIcon, ItemDataSOList.ItemTypeEnum.Hat);
            }
            
            for (int i = 0; i < ItemDataSOList.Ins.PantSO.DataList.Count; i++)
            {
                SpawnItemButton(ItemDataSOList.Ins.PantSO.DataList[i].GetTypeIcon, ItemDataSOList.ItemTypeEnum.Pant);
            }
            
            for (int i = 0; i < ItemDataSOList.Ins.ShieldSO.DataList.Count; i++)
            {
                SpawnItemButton(ItemDataSOList.Ins.ShieldSO.DataList[i].GetTypeIcon, ItemDataSOList.ItemTypeEnum.Shield);
            }
            
            for (int i = 0; i < ItemDataSOList.Ins.SkinSetSO.DataList.Count; i++)
            {
                SpawnItemButton(ItemDataSOList.Ins.SkinSetSO.DataList[i].GetTypeIcon, ItemDataSOList.ItemTypeEnum.SkinSet);
            }
        }
        private void SpawnItemButton(Sprite getIcon, ItemDataSOList.ItemTypeEnum itemType)
        {
            ItemButtonUI itemButton = Instantiate(itemButtonPrefab, itemParent);
            itemButton.SetIcon(getIcon);
            itemButton.gameObject.SetActive(false);
            itemButtonList.Add(itemButton);
            switch (itemType)
            {
                case ItemDataSOList.ItemTypeEnum.Hat:
                    itemButtonHatList.Add(itemButton);
                    break;
                case ItemDataSOList.ItemTypeEnum.Pant:
                    itemButtonPantList.Add(itemButton);
                    break;
                case ItemDataSOList.ItemTypeEnum.Shield:
                    itemButtonShieldList.Add(itemButton);
                    break;
                case ItemDataSOList.ItemTypeEnum.SkinSet:
                    itemButtonSkinSetList.Add(itemButton);
                    break;
            }
        }

        public void DespawnButton()
        {
            for (int i = 0; i < itemButtonList.Count; i++)
            {
                itemButtonList[i].gameObject.SetActive(false);
            }
        }
    }
}