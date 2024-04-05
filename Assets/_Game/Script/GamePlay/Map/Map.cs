using System;
using System.Collections.Generic;
using _Pool.Pool;
using UnityEngine;
using UnityEngine.AI;

namespace _Game.Script.GamePlay.Map
{
    [Serializable]
    public class Map : MonoBehaviour
    {
        [SerializeField] private Map map;
        [SerializeField] private NavMeshData navMeshData;
        
        // public Map MapObject => map;
        // public NavMeshData NavMeshData => navMeshData;
    }
}