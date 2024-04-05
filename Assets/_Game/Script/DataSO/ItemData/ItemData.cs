﻿using System;
using _Game.Script.DataSO.ItemData.HatData;
using UnityEngine;

namespace _Game.Script.DataSO.ItemData
{
    [Serializable]
    public class ItemData<Type>
    {
        [SerializeField] private Type type;
        [SerializeField] private Sprite TypeIcon;
        [SerializeField] private int price;
    }
}