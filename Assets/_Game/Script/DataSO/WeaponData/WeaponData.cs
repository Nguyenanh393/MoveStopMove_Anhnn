using System;
using _Game.Script.GamePlay.Weapon;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Script.DataSO.WeaponData
{
    [Serializable]
    public class WeaponData
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float attackRangeBonus;
        [SerializeField] private PoolType poolType;
        
        [SerializeField] private String weaponName;
        [SerializeField] private Sprite weaponImage;
        [SerializeField] private int price;
    }
}
