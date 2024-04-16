using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Script.DataSO.SizeData;
using _Game.Script.Level;
using _Game.Script.Manager;
using _Game.Script.OtherOpti;
using _Pool.Pool;
using _UI.Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Script.GamePlay.Character.Character
{
    public class Character : PoolUnit
    {
        [SerializeField] private Animator anim;
        [SerializeField] private Transform animTransform;
        [SerializeField] private CharacterAnim characterAnim;
        [SerializeField] private TargetIndicator targetIndicator;
        [SerializeField] private SizeSO sizeSO;
        [SerializeField] private AnimController animController;
        
        private AnimController.AnimType currentAnimType;

        private bool isDead;
        private int score = 0;

        protected int Score => score;

        protected void OnInit()
        {
            isDead = false;
            score = 0;
            TF.localScale = Vector3.one;
        }
        
        public bool IsDead
        {
            get => isDead;
            set => isDead = value;
        }

        public void SetAnim(AnimController.AnimType animType)
        {
            characterAnim.SetAnim(animType);
        }

        private void SetSize()
        {
            TF.localScale *= Constances.Range.BonusSizeRange; // hardcode cần sửa!
        }

        private void StopMove()
        {
            TF.position += Vector3.zero;
        }

        IEnumerator Despawn(float time)
        {
            yield return new WaitForSeconds(time);
            SimplePool.Despawn(this);
        }

        public void OnDie()
        {
            IsDead = true;
            StopMove();
            SetAnim(AnimController.AnimType.Die);
            StartCoroutine(Despawn(0.8f));
            CharacterManager.Ins.Characters = CharacterManager.Ins.Characters.FindAll(x => x != this);
        }

        public void SetScore()
        {
            score += 1;
            SetSize();
        }
    }
}