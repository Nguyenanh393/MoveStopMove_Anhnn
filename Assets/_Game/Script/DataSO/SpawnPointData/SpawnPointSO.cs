using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Script.GamePlay.Map
{
    [CreateAssetMenu(fileName = "SpawnPointSO", menuName = "ScriptableObjects/SpawnPoint")]
    public class SpawnPointSO : ScriptableObject
    {
        public List<SpawnPoint> spawnPoints;
        
        public List<SpawnPoint> SpawnPoints => spawnPoints;
    }
}