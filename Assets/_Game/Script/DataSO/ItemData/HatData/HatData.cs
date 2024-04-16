using System;
using _Pool.Pool;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Script.DataSO.ItemData.HatData
{
    [Serializable]
    public class HatData : ItemData<PoolUnit>
    {
        [SerializeField] private float attackRangeBonusPercent;
        
        public float AttackRangeBonusPercent => attackRangeBonusPercent;
        
        public String HatInfo()
        {
            return attackRangeBonusPercent + "% Range";
        }
    }
}