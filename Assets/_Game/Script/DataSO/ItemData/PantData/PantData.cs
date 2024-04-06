using System;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData.PantData
{
    [Serializable]
    public class PantData : ItemData<Material>
    {
        [SerializeField] private float moveSpeedBonusPercent;
        
        public float MoveSpeedBonusPercent => moveSpeedBonusPercent;

        public String PantInfo()
        {
            return moveSpeedBonusPercent + "% Move Speed";
        }
    }
}