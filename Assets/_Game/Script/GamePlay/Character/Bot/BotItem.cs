using System;
using _Game.Script.DataSO.ItemData;
using _Game.Script.GamePlay.Character.Character;
using _Game.Script.UserData;
using Random = UnityEngine.Random;

namespace _Game.Script.GamePlay.Character.Bot
{
    public class BotItem : CharacterItem
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
        
        private void SpawnAllItemEquippedState()
        {
            int hatIndex = Random.Range(0, ItemDataSOManager.Ins.HatSO.DataList.Count);
            ChangeHat(hatIndex);
            
            int pantIndex = Random.Range(0, ItemDataSOManager.Ins.PantSO.DataList.Count);
            ChangePant(pantIndex);
            
            // int? shieldIndex = DataManager.Ins.GetItemEquipped(ItemDataSOManager.ItemTypeEnum.Shield);
            // if (shieldIndex is not null)
            // {
            //     ChangeShield((int)shieldIndex);
            // }
            
        }
    }
}