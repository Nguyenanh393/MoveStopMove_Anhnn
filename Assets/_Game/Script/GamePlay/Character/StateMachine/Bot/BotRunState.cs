using _Game.Script;
using _Game.Script.GamePlay.Character.Bot;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.StateMachine.Bot
{
    public class BotRunState : IState<GamePlay.Character.Bot.Bot>
    {
        public void OnEnter(GamePlay.Character.Bot.Bot t)
        {
            //t.IsMoving = true;
            t.SetAnim(AnimController.AnimType.Run);
            t.Move();
        }

        public void OnExecute(GamePlay.Character.Bot.Bot t)
        {
            if (t.CanAttack)
            {
                //t.IsMoving = false;
                t.ChangeState(new BotAttackState());
            }

            if (t.IsTarget)
            {
                //t.IsMoving = false;
                t.ChangeState(new BotIdleState());
            }
        }

        public void OnExit(GamePlay.Character.Bot.Bot t)
        {
        }
    }
}