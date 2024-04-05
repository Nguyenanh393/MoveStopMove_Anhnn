using System;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData.PantData
{
    [Serializable]
    public class PantData
    {
        [SerializeField] private Material pant;
        [SerializeField] private float moveSpeedBonusPercent;
        [SerializeField] private Sprite pantIcon;
        [SerializeField] private int price;
    }
}