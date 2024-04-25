using System;
using System.Collections.Generic;
using _Game.Script.Manager;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Character
{
    public class AttackCircle : GameUnit
    {
        [SerializeField] private Character characterHolder;
        
        private List<Character> enemiesInRange = new List<Character>();
        private float attackRangeBonus = 0;
        public List<Character> EnemiesInRange => enemiesInRange;

        public float AttackRangeBonus
        {
            get => attackRangeBonus;
            set => attackRangeBonus = value;
        }
        public void OnInit()
        {
            TF.localScale = Vector3.one * (Constances.Range.DefaultAttackRange + attackRangeBonus);
            enemiesInRange.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constances.ColliderTag.CHARACTER))
            {
                Character character = Cache<Character>.GetComponent(other);
                EnemyEnterRange(character);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Constances.ColliderTag.CHARACTER))
            {
                Character character = Cache<Character>.GetComponent(other);
                EnemyExitRange(character);
            }
        }

        private void EnemyEnterRange(Character character)
        {
            if (!character.IsDead)
            {
                enemiesInRange.Add(character);
                if (characterHolder is Player.Player && enemiesInRange.Count == 1)
                {
                    CharacterManager.Ins.TargetIndicator = SimplePool.Spawn<TargetIndicator>(PoolType.TargetIndicator, character.TF);
                    CharacterManager.Ins.TargetIndicatorHolder = character;
                }
            }
        }
        
        
        private void EnemyExitRange(Character character)
        {
            enemiesInRange.Remove(character);
            if (character == CharacterManager.Ins.TargetIndicatorHolder)
            {
                SimplePool.Despawn(CharacterManager.Ins.TargetIndicator);
                if (enemiesInRange.Count > 0)
                {
                 CharacterManager.Ins.TargetIndicator = SimplePool.Spawn<TargetIndicator>(PoolType.TargetIndicator, enemiesInRange[0].TF);
                 CharacterManager.Ins.TargetIndicatorHolder = enemiesInRange[0];
                }
            } 
            
        }
    }
}