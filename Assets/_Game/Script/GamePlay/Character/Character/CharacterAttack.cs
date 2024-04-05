using System;
using System.Collections;
using _Game.Script.Level;
using _Game.Script.OtherOpti;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Character
{
    public class CharacterAttack : GameUnit
    {
        [SerializeField] private AttackCircle attackCircle;
        [SerializeField] private Weapon.Weapon weapon;
        [SerializeField] private Character character;
        [SerializeField] private PoolType poolType;
        
        private bool canAttack = false;        
        public bool CanAttack => canAttack;
        private void Update()
        {
            if (attackCircle.EnemiesInRange.Count > 0)
            {
                if (attackCircle.EnemiesInRange[0].IsDead)
                {
                    attackCircle.EnemiesInRange.RemoveAt(0);
                }
            }
            canAttack = attackCircle.EnemiesInRange.Count > 0 
                        && !attackCircle.EnemiesInRange[0].IsDead;
        }

        protected void OnInit()
        {
            canAttack = false;
            attackCircle.OnInit();
        }
        protected void Attack()
        {
            
            if (canAttack)
            {
                Character target = GetTarget();
                
                Vector3 position = target.TF.position;
                character.TF.LookAt(position);

                Vector3 characterPosition = TF.position;
                Vector3 direction = (position - characterPosition).normalized;
                Quaternion quaternion = Quaternion.LookRotation(direction) * Quaternion.Euler(-90, 0, 0);
                
                weapon.Throw(character, OnHitVictim, poolType, characterPosition + TF.forward * 0.8f + Vector3.up * 0.5f,  quaternion , direction, character);
                weapon.SetVisible(false);
                StartCoroutine(SetWeaponVisible(0.8f));
            }
            
            
        }

        private Character GetTarget()
        {
            if (canAttack)
            {
                if (attackCircle.EnemiesInRange.Count > 0 
                    &&!attackCircle.EnemiesInRange[0].IsDead) return attackCircle.EnemiesInRange[0];
            }
            return null;
        }
        private void OnHitVictim(Character attacker, Character victim)
        {
            if (victim.IsDead) return;
            victim.OnDie();
            attacker.SetScore();
        }
        IEnumerator SetWeaponVisible(float time)
        {
            yield return new WaitForSeconds(time);
            weapon.SetVisible(true);
        }
        
    }
}