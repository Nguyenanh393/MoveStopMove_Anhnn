using System;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData.PantData
{
    [Serializable]
    public class PantData : ItemData<Material>
    {
        [SerializeField] private float moveSpeedBonusPercent;
    }
}