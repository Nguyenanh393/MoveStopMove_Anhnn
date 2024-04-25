using System;
using _Game.Script.DataSO.ItemData;
using _Game.Script.Manager;
using _UI.Scripts.UI.ItemSkinShopButton;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _UI.Scripts.UI.SkinShopButton
{
    public class TopBarButtonUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private ItemDataSOManager.ItemTypeEnum itemType;
        [SerializeField] private Image buttonImage;
        
        public void SetData(Sprite icon, ItemDataSOManager.ItemTypeEnum itemType)
        {
            iconImage.sprite = icon;
            this.itemType = itemType;
        }

        public void OnClick()
        {
            
            CharacterManager.Ins.RespawnDancingPlayer();
            ItemSelectionUIManager.Ins.PlayerOnScene = CharacterManager.Ins.DancingPlayer;
            
            ItemSelectionUIManager.Ins.DespawnButton();
            ItemSelectionUIManager.Ins.SpawnItemButtons(ItemSelectionUIManager.Ins.GetItemButtonList(itemType));
            ItemSelectionUIManager.Ins.CurrentButton = null;
            ItemSelectionUIManager.Ins.SetButtonSelection(ItemSelectionUIManager.Ins.CurrentButton);
        }
    }
}