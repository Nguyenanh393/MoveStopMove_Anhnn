using System.Collections.Generic;
using _Game.Script.GamePlay.Character.Character;
using UnityEngine;

namespace _Game.Script.OtherOpti
{
    public static class Cache <T>
    {
        private static Dictionary<Collider, T> cacheList = new Dictionary<Collider, T>();

        public static T GetComponent(Collider collider)
        {
            if (!cacheList.ContainsKey(collider))
            {
                cacheList.Add(collider, collider.GetComponent<T>());
            }

            return cacheList[collider];
        }
    }
}