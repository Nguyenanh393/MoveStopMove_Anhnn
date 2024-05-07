using System.Collections;
using _Game.Script.DataSO.SizeData;
using _Game.Script.Manager;
using _Game.Script.OtherOpti;
using _Game.Script.UserData;
using _Pool.Pool;
using _UI.Scripts;
using _UI.Scripts.UI;
using UnityEngine;

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
        [SerializeField] private CharacterItem characterItem;
        private AnimController.AnimType currentAnimType;

        private bool isDead;
        private int score = 0;
        private float size;

        protected int Score => score;
        public float Size => size;

        protected void OnInit()
        {
            isDead = false;
            score = 0;
            size = 1f;
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
            TF.localScale *= Constances.Range.BonusSizeRange;
            size *= Constances.Range.BonusSizeRange;
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
            if (this == CharacterManager.Ins.TargetIndicatorHolder)
            {
                SimplePool.Despawn(CharacterManager.Ins.TargetIndicator);
            }
            CharacterManager.Ins.Characters = CharacterManager.Ins.Characters.FindAll(x => x != this);
            StartCoroutine(Despawn(0.8f));
            
            if (CharacterManager.Ins.Characters.Count == 1 && CharacterManager.Ins.Characters[0] == this)
            {
                UIManager.Ins.CloseAll();
                UIManager.Ins.OpenUI<Win>();
                GameManager.ChangeState(GameState.Win);
                UIManager.Ins.GetUI<Win>().SetScore(Score);
                DataManager.Ins.SetUserDataCoin(DataManager.Ins.GetUserDataCoin() + Score);
                return;
            }
            
            if (this is not Player.Player) return;
            GameManager.ChangeState(GameState.Lose);
            //UIManager.Ins.CloseUI<_UI.Scripts.GamePlay>();
            UIManager.Ins.OpenUI<Lose>().SetScore(Score);
            DataManager.Ins.SetUserDataCoin(DataManager.Ins.GetUserDataCoin() + Score);
            SimplePool.Despawn(CharacterManager.Ins.TargetIndicator);
        }

        public void SetScore()
        {
            score += 1;
            SetSize();
        }

        public Weapon.Weapon Weapon => characterItem.CurrentWeapon;
    }
}