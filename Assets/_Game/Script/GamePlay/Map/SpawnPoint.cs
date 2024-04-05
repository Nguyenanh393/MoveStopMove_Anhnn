using System;
using UnityEngine;

namespace _Game.Script.GamePlay.Map
{
    [Serializable]
    public class SpawnPoint
    {
        [SerializeField] private Vector3 position;
        [SerializeField] private Quaternion rotation;
        
        public Vector3 Position => position;
        public Quaternion Rotation => rotation;
    }
}