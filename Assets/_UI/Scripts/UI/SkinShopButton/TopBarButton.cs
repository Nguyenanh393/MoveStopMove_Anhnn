using System;
using _Game.Script.DataSO;
using _Game.Script.DataSO.ItemData;
using UnityEngine;

namespace _UI.Scripts.UI.SkinShopButton
{
    [Serializable]
    public class TopBarButton
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private ItemDataSOList.ItemTypeEnum itemType;
        
        public Sprite Icon => icon;
        public ItemDataSOList.ItemTypeEnum ItemType => itemType;
    }
}