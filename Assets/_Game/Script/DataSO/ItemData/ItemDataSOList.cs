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
    public class ItemDataSOList : Singleton<ItemDataSOList>
    {
        [SerializeField] private HatSO hatSO;
        [SerializeField] private PantSO pantSO;
        [SerializeField] private ShieldSO shieldSO;
        [SerializeField] private SkinSetSO skinSetSO;
        [SerializeField] private WeaponSO weaponSO;
        // public HatSO HatSO => hatSO;
        // public PantSO PantSO => pantSO;
        // public ShieldSO ShieldSO => shieldSO;
        //public WeaponSO WeaponSO => weaponSO;
        // public SkinSetSO SkinSetSO => skinSetSO;
        
        private Dictionary<ItemTypeEnum, object> dataSOMap;

        private void Awake()
        {
            dataSOMap = new Dictionary<ItemTypeEnum, object>();
            dataSOMap.Add(ItemTypeEnum.Hat, hatSO);
            dataSOMap.Add(ItemTypeEnum.Pant, pantSO);
            dataSOMap.Add(ItemTypeEnum.Shield, shieldSO);
            dataSOMap.Add(ItemTypeEnum.SkinSet, skinSetSO);
            dataSOMap.Add(ItemTypeEnum.Weapon, weaponSO);
        }
        public enum ItemTypeEnum
        {
            Hat,
            Pant,
            Shield,
            SkinSet,
            Weapon
        }

        public DataSO<T> GetDataSO<T>(ItemTypeEnum itemType)
        {
            return (DataSO<T>)dataSOMap[itemType];
        }
        
    }
}