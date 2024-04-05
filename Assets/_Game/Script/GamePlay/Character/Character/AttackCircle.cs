using System;
using System.Collections.Generic;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Character
{
    public class AttackCircle : GameUnit
    {
        [SerializeField] private Character characterHolder;
        
        private List<Character> enemiesInRange = new List<Character>();
        public List<Character> EnemiesInRange => enemiesInRange;

        public void OnInit()
        {
            TF.localScale = Vector3.one * Constances.Range.DefaultAttackRange;
            enemiesInRange.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constances.ColliderTag.CHARACTER))
            {
                Character character = Cache<Character>.GetComponet(other);
                EnemyEnterRange(character);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Constances.ColliderTag.CHARACTER))
            {
                Character character = Cache<Character>.GetComponet(other);
                EnemyExitRange(character);
            }
        }

        private void EnemyEnterRange(Character character)
        {
            if (!character.IsDead)
            {
                enemiesInRange.Add(character);
            }
        }
        
        
        private void EnemyExitRange(Character character)
        {
            enemiesInRange.Remove(character);
        }
    }
}