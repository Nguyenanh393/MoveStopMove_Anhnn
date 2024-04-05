
using _Game.Script.GamePlay.Character.Player;
using _Game.Script.OtherOpti;
using _Game.Script.RawInput;
using _UI.Scripts.UI;

namespace _Game.Script.GamePlay.Character.StateMachine.Player
{
    public class PlayerIdleState : IState<GamePlay.Character.Player.Player>
    {
        public void OnEnter(GamePlay.Character.Player.Player t)
        {
            t.StopMove();
            t.Attacked = false;
            t.SetAnim(AnimController.AnimType.Idle);
        }

        public void OnExecute(GamePlay.Character.Player.Player t)
        {
            
            if (t.isMoving())
            {
                t.ChangeState(new PlayerRunState());
            }
            else
            {
                if (t.CanAttack)
                {
                    t.ChangeState(new PlayerAttackState());
                }
            }
            
        }

        public void OnExit(GamePlay.Character.Player.Player t)
        {
            
        }
    }
}