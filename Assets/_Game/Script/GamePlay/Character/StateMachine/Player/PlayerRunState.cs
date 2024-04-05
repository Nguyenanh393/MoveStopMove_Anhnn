using _Game.Script.GamePlay.Character;
using _Game.Script.GamePlay.Character.Player;
using _Game.Script.OtherOpti;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.StateMachine.Player
{
    public class PlayerRunState : IState<GamePlay.Character.Player.Player>
    {
        public void OnEnter(GamePlay.Character.Player.Player t)
        {
            t.SetAnim(AnimController.AnimType.Run);
        }

        public void OnExecute(GamePlay.Character.Player.Player t)
        {
            
            if (!t.isMoving())
            {
                if (t.CanAttack)
                {
                    t.ChangeState(new PlayerAttackState());
                }
                else
                {
                    if (!t.IsDead)
                    {
                        t.ChangeState(new PlayerIdleState());
                    }
                }
                
            }
            t.Move();
        }

        public void OnExit(GamePlay.Character.Player.Player t)
        {
        }
    }
}