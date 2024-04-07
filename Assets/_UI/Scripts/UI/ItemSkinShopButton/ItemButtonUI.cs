using System;
using _Game.Script.DataSO;
using _Game.Script.DataSO.ItemData;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _UI.Scripts.UI.ItemSkinShopButton
{
    public class ItemButtonUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;

        private ItemDataSOManager.ItemTypeEnum itemType;
        private String itemInfo;
        private int itemPrice;
        
        private UnityAction onClickAction;
        
        public UnityAction OnClickAction
        {
            get => onClickAction;
            set => onClickAction = value;
        }
        
        public void SetData(Sprite icon, ItemDataSOManager.ItemTypeEnum nItemType, String nItemInfo, int nItemPrice)
        {
            iconImage.sprite = icon;
            itemType = nItemType;
            itemInfo = nItemInfo;
            itemPrice = nItemPrice;
        }
        public ItemDataSOManager.ItemTypeEnum ItemType => itemType;
        
        public String ItemInfo => itemInfo;
        
        public int ItemPrice => itemPrice;
        
        public void OnClick()
        {
            onClickAction?.Invoke();
        }
    }
}