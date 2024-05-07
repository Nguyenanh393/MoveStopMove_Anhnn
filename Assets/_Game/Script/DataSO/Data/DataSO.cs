using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace _Game.Script.DataSO.Data
{
    public class DataSO <T> : ScriptableObject
    {
        [SerializeField] List<T> dataList = new List<T>();
        
        public List<T> DataList => dataList;
        
        public void SaveToFile(String FILENAME)
        {
            var filePath = Path.Combine(Application.persistentDataPath, FILENAME);

            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }
       
            var json = JsonUtility.ToJson(this);
            File.WriteAllText(filePath, json);
        }
        

        public void LoadDataFromFile(String FILENAME)
        {
            var filePath = Path.Combine(Application.persistentDataPath, FILENAME);

            if(!File.Exists(filePath))
            {
                Debug.LogWarning($"File \"{filePath}\" not found!", this);
                return;
            }

            var json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}