using _Game.Script.DataSO.ItemData;
using _Game.Script.GamePlay.Character.Character;
using _Game.Script.UserData;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Player
{
    public class PlayerItem : CharacterItem
    {
        private void OnEnable()
        {
            OnInitItem();
        }

        public void OnInitItem()
        {
            OnInit();
            SpawnAllItemEquippedState();
        }
        public void TryItemInSkinShop(ItemDataSOManager.ItemTypeEnum itemType, int itemId)
        {
            switch (itemType)
            {
                case ItemDataSOManager.ItemTypeEnum.Hat:
                    DespawnHat();
                    ChangeHat(itemId);
                    break;
                case ItemDataSOManager.ItemTypeEnum.Pant:
                    DespawnPant();
                    ChangePant(itemId);
                    break;
                case ItemDataSOManager.ItemTypeEnum.Shield:
                    DespawnShield();
                    ChangeShield(itemId);
                    break;
                case ItemDataSOManager.ItemTypeEnum.SkinSet:
                    DespawnSkinSet();
                    ChangeSkinSet(itemId);
                    break;
            }
        }

        private void SpawnAllItemEquippedState()
        {
            int? weaponIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.Weapon);
            if (weaponIndex is not null)
            {
                Debug.Log("Weapon index: " + weaponIndex);
                ChangeWeapon((int)weaponIndex);
            }
            int? skinSetIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.SkinSet);
            if (skinSetIndex is not null)
            {
                ChangeSkinSet((int)skinSetIndex);
                return;
            }
            int? hatIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.Hat);
            if (hatIndex is not null)
            {
                ChangeHat((int)hatIndex);
            }
            
            int? pantIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.Pant);
            if (pantIndex is not null)
            {
                ChangePant((int)pantIndex);
            }
            
            int? shieldIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.Shield);
            if (shieldIndex is not null)
            {
                ChangeShield((int)shieldIndex);
            }
        }
    }
}