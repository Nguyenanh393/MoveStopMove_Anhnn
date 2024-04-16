using _Game.Script.Level;
using _Game.Script.Manager.RawInput;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Player
{
    public class PlayerMove : GameUnit
    {
        [SerializeField] private float speed;
        [SerializeField] private Player player;
        
        private FloatingJoystick floatingJoystick;
        
        public FloatingJoystick FloatingJoystick
        {
            get => floatingJoystick;
            set => floatingJoystick = value;
        }
        
        public Player Player
        {
            get => player;
            set => player = value;
        }
        public void Move()
        {
            if (InputManager.Ins.HasJoystick())
            {
                TF.LookAt(TF.position + new Vector3(floatingJoystick.Direction.x, 0, floatingJoystick.Direction.y));
                TF.position += TF.forward * (speed * Time.deltaTime);
            
            }
        }
        
        internal void StopMove()
        {
            TF.position += TF.forward * 0;
        }
    }
}
