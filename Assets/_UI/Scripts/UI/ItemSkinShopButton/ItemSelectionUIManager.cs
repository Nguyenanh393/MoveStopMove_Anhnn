using System;
using System.Collections.Generic;
using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.ItemData.HatData;
using _Game.Script.DataSO.ItemData.PantData;
using _Game.Script.DataSO.ItemData.ShieldData;
using _Game.Script.DataSO.ItemData.SkinSetData;
using _Game.Script.GamePlay.Character.Player;
using _Game.Script.Manager;
using _Game.Script.UserData;
using _UI.Scripts.UI.SkinShopButton;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.UI.ItemSkinShopButton
{
    public class ItemSelectionUIManager : Singleton<ItemSelectionUIManager>
    {
        [SerializeField] private ItemButtonUI itemButtonPrefab;
        [SerializeField] private Image itemSelectionImage;
        [SerializeField] private Transform itemParent;
        [SerializeField] private TopBarButtonSO itemButtonSO;

        [SerializeField] private Button buyButton;
        [SerializeField] private Button equipButton;
        [SerializeField] private Text buyButtonText;
        [SerializeField] private Text imageInfoText;
        
        private List<ItemButtonUI> itemButtonHatList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonPantList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonShieldList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonSkinSetList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonList = new List<ItemButtonUI>();
        
        private List<HatData> hatDataList;
        private List<PantData> pantDataList;
        private List<ShieldData> shieldDataList;
        private List<SkinSetData> skinSetDataList;
        
        private ItemButtonUI currentButton;
        private Player playerOnScene;

        public ItemButtonUI CurrentButton
        {
            get => currentButton;
            set => currentButton = value;
        }
        public Player PlayerOnScene
        {
            get => playerOnScene;
            set => playerOnScene = value;
        }
        private void Awake()
        {
            hatDataList = ItemDataSOManager.Ins.HatSO.DataList;
            pantDataList = ItemDataSOManager.Ins.PantSO.DataList;
            shieldDataList = ItemDataSOManager.Ins.ShieldSO.DataList;
            skinSetDataList = ItemDataSOManager.Ins.SkinSetSO.DataList;
            SpawnAllItemButton();
        }

        private void Start()
        {
            
        }

        private void OnEnable()
        {
            SpawnItemButtons(itemButtonHatList);
            SetButtonSelection(currentButton);
            playerOnScene = CharacterManager.Ins.DancingPlayer;
        }
        
        private void OnDisable()
        {
            DespawnButton();
            currentButton = null;
            SetButtonSelection(currentButton);
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
            for (int i = 0; i < hatDataList.Count; i++)
            {
                HatData hatData = hatDataList[i];
                SpawnItemButton(hatData.GetTypeIcon, hatData.HatInfo(), hatData.Price, ItemDataSOManager.ItemTypeEnum.Hat, i); }
            
            for (int i = 0; i < pantDataList.Count; i++)
            {
                PantData pantData = pantDataList[i];
                SpawnItemButton(pantData.GetTypeIcon, pantData.PantInfo(), pantData.Price, ItemDataSOManager.ItemTypeEnum.Pant, i);
            }
            
            for (int i = 0; i < shieldDataList.Count; i++)
            {
                ShieldData shieldData = shieldDataList[i];
                SpawnItemButton(shieldData.GetTypeIcon, shieldData.ShieldInfo(), shieldData.Price, ItemDataSOManager.ItemTypeEnum.Shield, i);
            }
            
            for (int i = 0; i < skinSetDataList.Count; i++)
            {
                SkinSetData skinSetData = skinSetDataList[i];
                SpawnItemButton(skinSetData.GetTypeIcon, skinSetData.SkinSetInfo(), skinSetData.Price, ItemDataSOManager.ItemTypeEnum.SkinSet, i);
            }
        }
        private void SpawnItemButton(Sprite getIcon, String getInfo, int getPrice, 
                                        ItemDataSOManager.ItemTypeEnum itemType, int index)
        {
            ItemButtonUI itemButton = Instantiate(itemButtonPrefab, itemParent);
            
            itemButton.SetData(getIcon, itemType, getInfo, getPrice, index);
            itemButton.gameObject.SetActive(false);
            itemButtonList.Add(itemButton);
            
            GetItemButtonList(itemType).Add(itemButton);
            
            itemButton.OnClickAction += () =>
            {
                SetButtonSelection(itemButton);
            };
        }

        private void SetItemInfo(ItemButtonUI itemButton)
        {
            imageInfoText.text = itemButton is null ? "" : itemButton.ItemInfo;
        }

        public void SetButtonSelection(ItemButtonUI itemButton)
        {
            currentButton = itemButton;
            SetItemInfo(itemButton);
            SetBottomBarButton(itemButton);
            if (itemButton is not null)
            {
                playerOnScene.TryItemInSkinShop(itemButton.ItemType, GetItemButtonList(itemButton.ItemType).IndexOf(itemButton));
            }
        }

        private void SetBottomBarButton(ItemButtonUI itemButton)
        {
            if (itemButton is null)
            {
                buyButton.gameObject.SetActive(false);
                equipButton.gameObject.SetActive(false);
                return;
            }
            int itemState = DataManager.Ins.GetItemState(itemButton.ItemType, GetItemButtonList(itemButton.ItemType).IndexOf(itemButton));
            switch (itemState)
            {
                case 0:
                    buyButton.gameObject.SetActive(true);
                    equipButton.gameObject.SetActive(false);
                    buyButtonText.text = "BUY " + itemButton.ItemPrice;
                    break;
                case 1:
                    buyButton.gameObject.SetActive(false);
                    equipButton.gameObject.SetActive(true);
                    break;
                case 2:
                    buyButton.gameObject.SetActive(false);
                    equipButton.gameObject.SetActive(false);
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