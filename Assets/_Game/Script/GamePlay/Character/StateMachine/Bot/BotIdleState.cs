using _Game.Script.GamePlay.Character.Bot;
using _Game.Script.GamePlay.Character.StateMachine.Player;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.StateMachine.Bot
{
    public class BotIdleState : IState<GamePlay.Character.Bot.Bot>
    {
        private float timer;
        public void OnEnter(GamePlay.Character.Bot.Bot t)
        {
            t.StopMove();
            t.Attacked = false;
            //t.IsMoving = false;
            t.SetAnim(AnimController.AnimType.Idle);
        }

        public void OnExecute(GamePlay.Character.Bot.Bot t)
        {
            timer += Time.deltaTime;
            if (t.CanAttack)
            {
                t.ChangeState(new BotAttackState());
            }
            else
            {
                if (!(timer > 0.2f)) return;
                //t.IsMoving = true;
                t.ChangeState(new BotRunState());
            }
            
            
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     t.ChangeState(new BotRunState());
            // }
        }

        public void OnExit(GamePlay.Character.Bot.Bot t)
        {
            
        }
    }
}