using System;
using System.Collections.Generic;
using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.ItemData.HatData;
using _Game.Script.DataSO.ItemData.PantData;
using _Game.Script.DataSO.ItemData.ShieldData;
using _Game.Script.DataSO.ItemData.SkinSetData;
using _Game.Script.UserData;
using _UI.Scripts.UI.SkinShopButton;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.UI.ItemSkinShopButton
{
    public class ItemSelectionUI : Singleton<ItemSelectionUI>
    {
        // có thể không cần sử dụng Singleton cho class này
        [SerializeField] private ItemButtonUI itemButtonPrefab;
        [SerializeField] private Image itemSelectionImage;
        [SerializeField] private Transform itemParent;
        [SerializeField] private TopBarButtonSO itemButtonSO;
        // Đẩy sang SkinShop
        [SerializeField] private Button buyButton;
        [SerializeField] private Button equipButton;
        [SerializeField] private Text buyButtonText;
        [SerializeField] private Text imageInfoText;
        
        private List<ItemButtonUI> itemButtonHatList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonPantList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonShieldList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonSkinSetList = new List<ItemButtonUI>();
        private List<ItemButtonUI> itemButtonList = new List<ItemButtonUI>();
        private List<Image> itemSelectionImages = new List<Image>();
        
        private List<HatData> hatDataList;
        private List<PantData> pantDataList;
        private List<ShieldData> shieldDataList;
        private List<SkinSetData> skinSetDataList;
        
        private ItemButtonUI currentButton;
        private void OnEnable()
        {
            hatDataList = ItemDataSOManager.Ins.HatSO.DataList;
            pantDataList = ItemDataSOManager.Ins.PantSO.DataList;
            shieldDataList = ItemDataSOManager.Ins.ShieldSO.DataList;
            skinSetDataList = ItemDataSOManager.Ins.SkinSetSO.DataList;
            
            SpawnAllItemButton();
            SpawnItemButtons(itemButtonHatList);
            currentButton = itemButtonList[0];
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
                SpawnItemButton(hatData.GetTypeIcon, hatData.HatInfo(), hatData.Price, ItemDataSOManager.ItemTypeEnum.Hat); }
            
            for (int i = 0; i < pantDataList.Count; i++)
            {
                PantData pantData = pantDataList[i];
                SpawnItemButton(pantData.GetTypeIcon, pantData.PantInfo(), pantData.Price, ItemDataSOManager.ItemTypeEnum.Pant);
            }
            
            for (int i = 0; i < shieldDataList.Count; i++)
            {
                ShieldData shieldData = shieldDataList[i];
                SpawnItemButton(shieldData.GetTypeIcon, shieldData.ShieldInfo(), shieldData.Price, ItemDataSOManager.ItemTypeEnum.Shield);
            }
            
            for (int i = 0; i < skinSetDataList.Count; i++)
            {
                SkinSetData skinSetData = skinSetDataList[i];
                SpawnItemButton(skinSetData.GetTypeIcon, skinSetData.SkinSetInfo(), skinSetData.Price, ItemDataSOManager.ItemTypeEnum.SkinSet);
            }
        }
        private void SpawnItemButton(Sprite getIcon, String getInfo, int getPrice, 
                                        ItemDataSOManager.ItemTypeEnum itemType)
        {
            ItemButtonUI itemButton = Instantiate(itemButtonPrefab, itemParent);
            Image itemButtonImage = Instantiate(itemSelectionImage, itemButton.transform);
            
            itemButton.SetData(getIcon, itemType, getInfo, getPrice);
            
            itemButton.gameObject.SetActive(false);
            itemButtonImage.gameObject.SetActive(false);
            
            itemSelectionImages.Add(itemButtonImage);
            itemButtonList.Add(itemButton);
            
            GetItemButtonList(itemType).Add(itemButton);
            
            itemButton.OnClickAction += () =>
            {
                // có thể cho 1 biến currentButton để lưu lại button hiện tại
                // và so sánh với button được click để không phải duyệt qua 
                // tất cả selectionImages => tăng hiệu suất
                // (Đoán thế)
                SetButtonSelection(itemButton);
            };
        }

        private void SetItemInfo(ItemButtonUI itemButton)
        {
            imageInfoText.text = itemButton.ItemInfo;
        }

        public void SetButtonSelection(ItemButtonUI itemButton)
        {
            itemSelectionImages[itemButtonList.IndexOf(currentButton)].gameObject.SetActive(false);
            itemSelectionImages[itemButtonList.IndexOf(itemButton)].gameObject.SetActive(true);
            currentButton = itemButton;
            SetItemInfo(itemButton);
            SetBottomBarButton(itemButton);
        }

        private void SetBottomBarButton(ItemButtonUI itemButton)
        {
            int itemState = DataManager.Ins.GetItemState(itemButton.ItemType, GetItemButtonList(itemButton.ItemType).IndexOf(itemButton));
            switch (itemState)
            {
                case 0:
                    buyButton.gameObject.SetActive(true);
                    equipButton.gameObject.SetActive(false);
                    buyButtonText.text = "Buy";
                    break;
                case 1:
                    buyButton.gameObject.SetActive(false);
                    equipButton.gameObject.SetActive(true);
                    buyButtonText.text = "Equip";
                    break;
                case 2:
                    buyButton.gameObject.SetActive(false);
                    equipButton.gameObject.SetActive(false);
                    break;
            }
        }

        public void DespawnButton()
        {
            // có thể chỉ deactivate list của itemType hiện tại
            // bị lỗi vì ko xóa hết button khi chuyển từ Hat sang Pant
            //itemSelectionImages[itemButtonList.IndexOf(currentButton)].gameObject.SetActive(false);
            for (int i = 0; i < itemButtonList.Count; i++)
            {
                itemButtonList[i].gameObject.SetActive(false);
            }
        }
    }
}