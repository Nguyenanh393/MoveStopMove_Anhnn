using System;
using _Game.Script.DataSO;
using _Game.Script.DataSO.ItemData;
using _UI.Scripts.UI.ItemSkinShopButton;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.UI.SkinShopButton
{
    public class TopBarButtonUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private ItemDataSOList.ItemTypeEnum itemType;

        private ItemDataSOList.ItemTypeEnum currentItemType;
        public void SetData(Sprite icon, ItemDataSOList.ItemTypeEnum itemType)
        {
            iconImage.sprite = icon;
            this.itemType = itemType;
        }
        
        public void OnClick()
        {
            ItemSelectionUI.Ins.DespawnButton();
            currentItemType = itemType;
            ItemSelectionUI.Ins.SpawnItemButtons(ItemSelectionUI.Ins.GetItemButtonList(itemType));
        }
    }
}