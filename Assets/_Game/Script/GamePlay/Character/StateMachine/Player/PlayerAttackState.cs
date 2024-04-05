using _Game.Script.GamePlay.Character.Player;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.StateMachine.Player
{
    public class PlayerAttackState : IState<GamePlay.Character.Player.Player>
    {
        private float timer;
        public void OnEnter(GamePlay.Character.Player.Player t)
        {
            //t.StopMove();
            t.SetAnim(AnimController.AnimType.Attack);
            t.Attack();
            //t.Attacked = true;
        }

        public void OnExecute(GamePlay.Character.Player.Player t)
        {
            if (t.Attacked)
            {
                timer += Time.deltaTime;
                if (timer > 0.8f)
                {
                    if (!t.IsDead)
                    {
                        t.ChangeState(new PlayerIdleState());
                    }
                }
            }
            if (t.isMoving())
            {
                t.ChangeState(new PlayerRunState());
            }
        }

        public void OnExit(GamePlay.Character.Player.Player t)
        {
            
        }
    }
}