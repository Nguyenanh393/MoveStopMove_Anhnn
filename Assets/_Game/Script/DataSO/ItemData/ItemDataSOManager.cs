using System.Collections.Generic;
using _Game.Script.DataSO.ItemData.HatData;
using _Game.Script.DataSO.ItemData.PantData;
using _Game.Script.DataSO.ItemData.ShiedData;
using _Game.Script.DataSO.ItemData.SkinSetData;
using _Game.Script.DataSO.WeaponData;
using _UI.Scripts.UI.SkinShopButton;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData
{
    public class ItemDataSOManager : Singleton<ItemDataSOManager>
    {
        [SerializeField] private HatSO hatSO;
        [SerializeField] private PantSO pantSO;
        [SerializeField] private ShieldSO shieldSO;
        [SerializeField] private SkinSetSO skinSetSO;
        [SerializeField] private WeaponSO weaponSO;
        
        public HatSO HatSO => hatSO;
        public PantSO PantSO => pantSO;
        public ShieldSO ShieldSO => shieldSO;
        public SkinSetSO SkinSetSO => skinSetSO;
        public WeaponSO WeaponSO => weaponSO;
        public enum ItemTypeEnum
        {
            Hat,
            Pant,
            Shield,
            SkinSet,
            Weapon
        }
    }
}