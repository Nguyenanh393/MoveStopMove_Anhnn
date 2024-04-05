using System;
using System.Collections;
using _Game.Script.OtherOpti;
using _Pool.Pool;
using UnityEngine;

namespace _Game.Script.GamePlay.Weapon.Bullet
{
    public class Bullet : PoolUnit
    {
        private Vector3 direction;
        public Rigidbody rb;
        private Character.Character.Character owner;
        private Character.Character.Character attacker;
        private Character.Character.Character victim;
    
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

        private void Update()
        {
            if (attacker.IsDead)
            {
                OnDespawn();
            }
        }

        public void OnInit()
        {
            rb.velocity = direction * 5f;
        }

        public void OnDespawn()
        {
            SimplePool.Despawn(this);
        }

        protected Action<Character.Character.Character, Character.Character.Character> onHit;
    
        // set bullet data for bullet
        public virtual void OnInit(Character.Character.Character attacker, Action<Character.Character.Character, Character.Character.Character> onHit)
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
            }
            else
            {
                if (other.CompareTag(Constances.ColliderTag.WALL))
                {
                    StartCoroutine(StopMoving());
                }
                else
                {
                    Invoke(nameof(OnDespawn), 1f);
                }
            }
        
        }

        private IEnumerator StopMoving()
        {
            rb.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.3f);
            OnDespawn();
        }
    }
}
