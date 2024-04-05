using System;
using _Game.Script.DataSO.ItemData.PantData;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData.ShiedData
{
    [Serializable]
    public class ShiedData
    {
        [SerializeField] private Shied shied;
        [SerializeField] private float goldBonusPercent;
        [SerializeField] private int price;
    }
}