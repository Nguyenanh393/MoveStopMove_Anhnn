using _Game.Script.GamePlay.Character.StateMachine.Bot;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;
using UnityEngine.AI;

namespace _Game.Script.GamePlay.Character.Bot
{
    public class Bot : Character.Character
    {
        [SerializeField] private BotAttack botAttack;
        [SerializeField] private BotMove botMove;
        [SerializeField] private BotItem botItem;
        
        private IState<Bot> currentState;
        
        public bool Attacked
        {
            get => botAttack.Attacked;
            set => botAttack.Attacked = value;
        }

        public bool CanAttack => botAttack.CanAttack;
        
        void Update()
        {
            if (IsDead) return;
            if (!GameManager.IsState(GameState.MainMenu))
            {
                botMove.EnableNavMeshAgent();
                if (currentState != null)
                {
                    currentState.OnExecute(this);
                } 
            }
            
            // if (GameManager.IsState(GameState.Setting))
            // {
            //     StopMove();
            //     SetAnim(AnimController.AnimType.Idle);
            // }
        }

        protected internal void OnInitBot()
        {
            OnInit();
            botMove.OnInit();
            ChangeState(new BotIdleState());
            botAttack.OnInit();
            botItem.ChangeWeapon(botAttack.WeaponIndex);
        }
        public void ChangeState(IState<Bot> state)
        {
            if (currentState != null)
            {
                currentState.OnExit(this);
            }
        
            currentState = state;
        
            if (currentState != null)
            {
                currentState.OnEnter(this);
            }
        }
        
        public void Move() => botMove.Move();
        public void StopMove() => botMove.StopMove();

        public bool IsTarget => botMove.IsDestination;
        public void Attack()
        {
            StopMove();
            botAttack.Attack();
        }
        
        // public bool IsMoving
        // {
        //     get => botMove.IsMoving;
        //     set => botMove.IsMoving = value;
        // }
        
    }
}
