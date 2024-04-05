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
    }
}