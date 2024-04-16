using System;
using _Game.Script.DataSO.ItemData;
using _Game.Script.GamePlay.Weapon;
using _Pool.Pool;
using UnityEngine;

namespace _Game.Script.DataSO.WeaponData
{
    [Serializable]
    public class WeaponData : ItemData<Weapon>
    {
        [SerializeField] private float attackSpeed;
        [SerializeField] private float attackRangeBonus;
        //[SerializeField] private PoolType poolType;
        [SerializeField] private PoolType bulletPoolType;
        [SerializeField] private String weaponName;
        
        public float AttackSpeed => attackSpeed;
        public float AttackRangeBonus => attackRangeBonus;
        //public PoolType PoolType => poolType;
        public string WeaponName => weaponName;
        public PoolType BulletPoolType => bulletPoolType;
        public string WeaponInfo()
        {
            String weaponInfo = "";
            if (attackSpeed > 0)
            {
                weaponInfo += "+ " + attackSpeed + " Speed";
            }
            if (attackRangeBonus > 0)
            {
                weaponInfo += "+ " + attackRangeBonus + " Range";
            }
            
            return weaponInfo;
        }
    }
}
