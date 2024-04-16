﻿using System;
using System.Collections;
using _Game.Script.DataSO.ItemData;
using _Game.Script.DataSO.WeaponData;
using _Game.Script.UserData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Script.GamePlay.Character.Character
{
    public class CharacterAttack : GameUnit
    {
        [SerializeField] private AttackCircle attackCircle;
        [SerializeField] private Character character;
 
        private PoolType poolType;
        private Weapon.Weapon weapon;
        private bool canAttack = false;   
        public bool CanAttack => canAttack;
        private int weaponIndex;
        private TargetIndicator targetIndicator;
        private WeaponData weaponData;
        public int WeaponIndex
        {
            get => weaponIndex;
            set => weaponIndex = value;
        }

        public TargetIndicator TargetIndicator => targetIndicator;
        public PoolType PoolType
        {
            get => poolType;
            set => poolType = value;
        }

        public Weapon.Weapon Weapon
        {
            get => weapon;
            set => weapon = value;
        }
        
        public WeaponData WeaponData
        {
            get => weaponData;
            set => weaponData = value;
        }

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
                if (this is Player.PlayerAttack)
                {
                    targetIndicator = SimplePool.Spawn<TargetIndicator>(PoolType.TargetIndicator, position, Quaternion.identity);
                }
                Vector3 characterPosition = TF.position;
                Vector3 direction = (position - characterPosition).normalized;
                Quaternion quaternion = Quaternion.LookRotation(direction) * Quaternion.Euler(-90, 0, 0);

                weapon.Throw(character, OnHitVictim, poolType,
                    characterPosition + TF.forward * 0.8f + Vector3.up * 0.5f, quaternion, direction, character);//, weaponData.AttackSpeed, weaponData.AttackRangeBonus);
                weapon.SetVisible(false);
                StartCoroutine(SetWeaponVisible(0.8f)); 
            }
        }

        private Character GetTarget()
        {
            return attackCircle.EnemiesInRange[0];
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