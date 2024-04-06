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
        private void Start()
        {
            SpawnAllItemButton();
            SpawnItemButtons(itemButtonHatList);
        }
        
        public List<ItemButtonUI> GetItemButtonList(ItemDataSOManager.ItemTypeEnum itemType)
        {
            switch (itemType)
            {
                case ItemDataSOManager.ItemTypeEnum.Hat:
                    return itemButtonHatList;
                case ItemDataSOManager.ItemTypeEnum.Pant:
                    return itemButtonPantList;
                case ItemDataSOManager.ItemTypeEnum.Shield:
                    return itemButtonShieldList;
                case ItemDataSOManager.ItemTypeEnum.SkinSet:
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
            for (int i = 0; i < ItemDataSOManager.Ins.HatSO.DataList.Count; i++)
            {
                SpawnItemButton(ItemDataSOManager.Ins.HatSO.DataList[i].GetTypeIcon, ItemDataSOManager.ItemTypeEnum.Hat);
            }
            
            for (int i = 0; i < ItemDataSOManager.Ins.PantSO.DataList.Count; i++)
            {
                SpawnItemButton(ItemDataSOManager.Ins.PantSO.DataList[i].GetTypeIcon, ItemDataSOManager.ItemTypeEnum.Pant);
            }
            
            for (int i = 0; i < ItemDataSOManager.Ins.ShieldSO.DataList.Count; i++)
            {
                SpawnItemButton(ItemDataSOManager.Ins.ShieldSO.DataList[i].GetTypeIcon, ItemDataSOManager.ItemTypeEnum.Shield);
            }
            
            for (int i = 0; i < ItemDataSOManager.Ins.SkinSetSO.DataList.Count; i++)
            {
                SpawnItemButton(ItemDataSOManager.Ins.SkinSetSO.DataList[i].GetTypeIcon, ItemDataSOManager.ItemTypeEnum.SkinSet);
            }
        }
        private void SpawnItemButton(Sprite getIcon, ItemDataSOManager.ItemTypeEnum itemType)
        {
            ItemButtonUI itemButton = Instantiate(itemButtonPrefab, itemParent);
            itemButton.SetIcon(getIcon);
            itemButton.gameObject.SetActive(false);
            itemButtonList.Add(itemButton);
            switch (itemType)
            {
                case ItemDataSOManager.ItemTypeEnum.Hat:
                    itemButtonHatList.Add(itemButton);
                    break;
                case ItemDataSOManager.ItemTypeEnum.Pant:
                    itemButtonPantList.Add(itemButton);
                    break;
                case ItemDataSOManager.ItemTypeEnum.Shield:
                    itemButtonShieldList.Add(itemButton);
                    break;
                case ItemDataSOManager.ItemTypeEnum.SkinSet:
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