using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Script.DataSO.ItemData.HatData
{
    [Serializable]
    public class HatData
    {
        [SerializeField] private Hat hat;
        [SerializeField] private float attackRangeBonusPercent;
        [SerializeField] private Sprite hatIcon;
        [SerializeField] private int price;
    }
}