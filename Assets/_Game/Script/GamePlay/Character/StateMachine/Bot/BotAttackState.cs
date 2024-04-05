using _Game.Script.GamePlay.Character.Bot;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.StateMachine.Bot
{
    public class BotAttackState : IState<GamePlay.Character.Bot.Bot>
    {
        private float timer;
        public void OnEnter(GamePlay.Character.Bot.Bot t)
        {
            //t.StopMove();
            t.SetAnim(AnimController.AnimType.Attack);
            t.Attack();
            //t.Attacked = true;
        }

        public void OnExecute(GamePlay.Character.Bot.Bot t)
        {
            if (t.Attacked)
            {
                timer += Time.deltaTime;
                if (timer > 0.8f)
                {
                    t.ChangeState(new BotIdleState());
                }
            }
        }

        public void OnExit(GamePlay.Character.Bot.Bot t)
        {
            
        }
    }
}