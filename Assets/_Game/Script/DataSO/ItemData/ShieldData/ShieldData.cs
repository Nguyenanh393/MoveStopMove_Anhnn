using System;
using _Game.Script.DataSO.ItemData.ShiedData;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData.ShieldData
{
    [Serializable]
    public class ShieldData : ItemData<Shield>
    {
        [SerializeField] private float goldBonusPercent;
        
        public float GoldBonusPercent => goldBonusPercent;

        public String ShieldInfo()
        {
            return goldBonusPercent + "% Gold";
        }
    }
}