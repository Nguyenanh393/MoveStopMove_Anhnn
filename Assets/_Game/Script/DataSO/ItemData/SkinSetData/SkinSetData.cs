using System;
using _Game.Script.DataSO.ItemData.ShiedData;
using _Game.Script.GamePlay.Character.Player;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData.SkinSetData
{
    [Serializable]
    public class SkinSetData : ItemData<Player>
    {
        [SerializeField] private PoolType poolType;
        [SerializeField] private float attackRangeBonusPercent;
        [SerializeField] private float moveSpeedBonusPercent;
        [SerializeField] private float goldBonusPercent;
        
        public PoolType PoolType => poolType;
        public float AttackRangeBonusPercent => attackRangeBonusPercent;
        public float MoveSpeedBonusPercent => moveSpeedBonusPercent;
        public float GoldBonusPercent => goldBonusPercent;

        public String SkinSetInfo()
        {
            String skinSetInfo = "";
            if (attackRangeBonusPercent > 0)
            {
                skinSetInfo += "+ " + attackRangeBonusPercent + "% Range";
            }

            if (moveSpeedBonusPercent > 0)
            {
                skinSetInfo += "+ " + moveSpeedBonusPercent + "% Move Speed";
            }

            if (goldBonusPercent > 0)
            {
                skinSetInfo += "+ " + goldBonusPercent + "% Gold";
            }

            return skinSetInfo;
        }
    }
}