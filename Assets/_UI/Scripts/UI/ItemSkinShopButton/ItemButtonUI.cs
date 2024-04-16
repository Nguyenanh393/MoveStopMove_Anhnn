using System;
using System.Net.Mime;
using _Game.Script.DataSO;
using _Game.Script.DataSO.ItemData;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _UI.Scripts.UI.ItemSkinShopButton
{
    public class ItemButtonUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private Image stateImage;
        private ItemDataSOManager.ItemTypeEnum itemType;
        private String itemInfo;
        private int itemPrice;
        private int itemIds;
        private UnityAction onClickAction;
        
        public UnityAction OnClickAction
        {
            get => onClickAction;
            set => onClickAction = value;
        }
        
        public void SetData(Sprite icon, ItemDataSOManager.ItemTypeEnum nItemType, String nItemInfo, int nItemPrice, int nItemIds)
        {
            iconImage.sprite = icon;
            itemType = nItemType;
            itemInfo = nItemInfo;
            itemPrice = nItemPrice;
            itemIds = nItemIds;
        }
        public ItemDataSOManager.ItemTypeEnum ItemType => itemType;

        public Image StateImage => stateImage;
        public String ItemInfo => itemInfo;
        
        public int ItemPrice => itemPrice;
        
        public int ItemIds => itemIds;
        public void OnClick()
        {
            onClickAction?.Invoke();
        }
    }
}