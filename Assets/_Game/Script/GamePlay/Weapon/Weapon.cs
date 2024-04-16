using System;
using _Game.Script.DataSO.ItemData;
using _Game.Script.UserData;
using _Pool.Pool;
using UnityEngine;

namespace _Game.Script.GamePlay.Weapon
{
    public class Weapon : PoolUnit
    {
        [SerializeField] private Character.Character.Character owner;
        
        public Character.Character.Character Owner
        {
            get => owner;
            set => owner = value;
        }

        public void SetVisible(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
        
        public void Throw(Character.Character.Character character, Action<Character.Character.Character, Character.Character.Character> onHit,
            PoolType nPoolType, Vector3 position, Quaternion rotation, Vector3 direction, Character.Character.Character owner)//, float speed, float distance) // speed, distance
        {
            Bullet.Bullet bullet = SimplePool.Spawn<Bullet.Bullet>(nPoolType, position, rotation);
            //bullet.gameObject.SetActive(true);
            
            bullet.Direction = direction;
            bullet.TF.rotation = rotation;
            bullet.Owner = owner;
            
            // bullet.Speed = speed;
            // bullet.Distance = distance;
            bullet.OnInit(character, onHit);
        }
    }
}