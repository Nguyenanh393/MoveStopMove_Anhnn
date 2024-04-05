using System.Collections.Generic;
using UnityEngine;

namespace _Game.Script.DataSO
{
    public class DataSO <T> : ScriptableObject
    {
        [SerializeField] List<T> dataList = new List<T>();
        
        public List<T> DataList => dataList;
    }
}