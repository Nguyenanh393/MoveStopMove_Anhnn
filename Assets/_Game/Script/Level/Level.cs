using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Script.Level
{
    [Serializable]
    public class Level
    {
        [SerializeField] private int mapId;
        [SerializeField] private int numberOfBots;
    
        public int MapId => mapId;
        public int NumberOfBots => numberOfBots;
    }
}