using System;
using _Game.Script.DataSO.ItemData.PantData;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData.ShiedData
{
    [Serializable]
    public class ShiedData : ItemData<Shied>
    {
        [SerializeField] private float goldBonusPercent;
    }
}