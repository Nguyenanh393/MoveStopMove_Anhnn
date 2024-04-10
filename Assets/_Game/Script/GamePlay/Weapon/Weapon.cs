using System;
using UnityEngine;

namespace _Game.Script.GamePlay.Weapon
{
    public class Weapon : GameUnit
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
            PoolType nPoolType, Vector3 position, Quaternion rotation, Vector3 direction, Character.Character.Character owner)
        {
            Bullet.Bullet bullet = SimplePool.Spawn<Bullet.Bullet>(nPoolType, position, rotation);
            //bullet.gameObject.SetActive(true);
            
            bullet.Direction = direction;
            bullet.TF.rotation = rotation;
            bullet.Owner = owner;
            bullet.OnInit(character, onHit);
        }
    }
}