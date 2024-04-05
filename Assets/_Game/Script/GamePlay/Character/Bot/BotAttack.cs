using System.Collections;
using _Game.Script.GamePlay.Character.Character;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Bot
{
    public class BotAttack : CharacterAttack
    {
        private bool attacked = false;

        public void OnInit()
        {
            attacked = false;
            base.OnInit();
        }
        public bool Attacked
        {
            get => attacked;
            set => attacked = value;
        }
        public void Attack()
        {
            base.Attack();
            StartCoroutine(SetAttacked(true));
        }
        
        IEnumerator SetAttacked(bool att)
        {
            yield return new WaitForSeconds(0.8f);
            attacked = att;
        }
    }
}