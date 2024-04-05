using System.Collections.Generic;
using UnityEngine;

namespace _Game.Script.Level
{
    [CreateAssetMenu(fileName = "LevelDataSO", menuName = "ScriptableObjects/LevelData")]
    public class LevelDataSO : ScriptableObject
    {
        public List<Level> levels;
        
        public Level GetLevel(int index)
        {
            return levels[index];
        }
    }
}