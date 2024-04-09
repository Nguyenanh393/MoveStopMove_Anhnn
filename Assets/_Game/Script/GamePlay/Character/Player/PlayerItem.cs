using System;
using _Game.Script.DataSO.ItemData;
using _Game.Script.GamePlay.Character.Character;
using _UI.Scripts.UI.ItemSkinShopButton;

namespace _Game.Script.GamePlay.Character.Player
{
    public class PlayerItem : CharacterItem
    {
        private void OnEnable()
        {
            OnInit();
        }

        private void TryItemInSkinShop(ItemDataSOManager.ItemTypeEnum itemType, int itemId)
        {
            switch (itemType)
            {
                case ItemDataSOManager.ItemTypeEnum.Hat:
                    ChangeHat(itemId);
                    break;
                case ItemDataSOManager.ItemTypeEnum.Pant:
                    ChangePant(itemId);
                    break;
                case ItemDataSOManager.ItemTypeEnum.Shield:
                    ChangeShield(itemId);
                    break;
            }
        }
    }
}