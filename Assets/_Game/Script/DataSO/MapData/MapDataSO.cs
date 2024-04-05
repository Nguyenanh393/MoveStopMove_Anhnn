using System.Collections.Generic;
using UnityEngine;

namespace _Game.Script.GamePlay.Map
{
    [CreateAssetMenu(fileName = "MapDataSO", menuName = "ScriptableObjects/MapData")]
    public class MapDataSO : ScriptableObject
    {
        public List<Map> maps;
        
        public Map Map(int index)
        {
            return maps[index];
        }
    }
}