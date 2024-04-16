using System;
using System.Collections;
using _Game.Script.OtherOpti;
using _Pool.Pool;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game.Script.GamePlay.Weapon.Bullet
{
    public class Bullet : PoolUnit
    {
        private Vector3 direction;
        public Rigidbody rb;
        private Character.Character.Character owner;
        private Character.Character.Character attacker;
        private Character.Character.Character victim;
    
        private float speed;
        private float distance;
        public float Speed
        {
            get => speed;
            set => speed = value;
        }
        
        public float Distance
        {
            get => distance;
            set => distance = value;
        }
        
        public Vector3 Direction
        {
            get => direction;
            set => direction = value;
        }

        public Character.Character.Character Owner
        {
            get => owner;
            set => owner = value;
        }
        
        public void OnDespawn()
        {
            SimplePool.Despawn(this);
        }

        private Action<Character.Character.Character, Character.Character.Character> onHit;
    
        // set bullet data for bullet
        public void OnInit(Character.Character.Character attacker, Action<Character.Character.Character, Character.Character.Character> onHit)
        {
            this.attacker = attacker;
            this.onHit = onHit;
            rb.velocity = direction * 5f;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constances.ColliderTag.CHARACTER))
            {
                Character.Character.Character victim = Cache<Character.Character.Character>.GetComponet(other);
                if (victim == attacker)
                {
                    return;
                }
                onHit?.Invoke(attacker,victim);
                OnDespawn();
            }
            else
            {
                if (other.CompareTag(Constances.ColliderTag.WALL))
                {
                    StartCoroutine(StopMoving());
                }
                else
                {
                    // if (poolType == PoolType.Bomerang)
                    // {
                    //     Invoke(nameof(ReturnToOwner), 2f); // time => quang duong
                    // }
                    // else
                    // {
                        Invoke(nameof(OnDespawn), 1f); // time => quang duong
                    // }
                    
                }
            }
        
        }

        private IEnumerator StopMoving()
        {
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.3f);
            OnDespawn();
        }
        
        public void ReturnToOwner()
        {
            rb.velocity = (owner.TF.position - TF.position).normalized * 5f;
            Invoke(nameof(OnDespawn), 2f); // quang duong
        }
    }
}
