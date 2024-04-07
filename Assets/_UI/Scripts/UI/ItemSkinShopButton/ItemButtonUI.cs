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
        
        public UnityAction onClickAction;

        public void SetIcon(Sprite icon)
        {
            iconImage.sprite = icon;
        }

        public ItemDataSOManager.ItemTypeEnum ItemType
        {
            get => itemType;
            set => itemType = value;
        }
        
        public String ItemInfo
        {
            get => itemInfo;
            set => itemInfo = value;
        }
        
        public int ItemPrice
        {
            get => itemPrice;
            set => itemPrice = value;
        }
        
        public void OnClick()
        {
            onClickAction?.Invoke();
        }
    }
}