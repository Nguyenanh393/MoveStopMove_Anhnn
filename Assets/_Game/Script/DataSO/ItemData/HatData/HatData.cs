using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Script.DataSO.ItemData.HatData
{
    [Serializable]
    public class HatData : ItemData<Hat>
    {
        [SerializeField] private float attackRangeBonusPercent;
    }
}