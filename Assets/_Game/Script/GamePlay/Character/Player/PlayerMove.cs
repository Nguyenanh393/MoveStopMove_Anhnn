using _Game.Script.Level;
using _Game.Script.RawInput;
using UnityEngine;

namespace _Game.Script.GamePlay.Character.Player
{
    public class PlayerMove : GameUnit
    {
        [SerializeField] private float speed;
        [SerializeField] private Player player;
        
        private VariableJoystick variableJoystick;
        
        public VariableJoystick VariableJoystick
        {
            get => variableJoystick;
            set => variableJoystick = value;
        }
        
        public Player Player
        {
            get => player;
            set => player = value;
        }

        // private void Start()
        // {
        //     OnInit();
        // }
        

        public void Move()
        {
            if (InputManager.Ins.HasJoystick())
            {
                float angle = Mathf.Atan2(variableJoystick.Direction.x, variableJoystick.Direction.y) * Mathf.Rad2Deg;
                // TF.rotation = Quaternion.Euler(0, angle, 0);
                TF.LookAt(TF.position + new Vector3(variableJoystick.Direction.x, 0, variableJoystick.Direction.y));
                TF.position += TF.forward * (speed * Time.deltaTime);
            
            }
        }
        
        internal void StopMove()
        {
            TF.position += TF.forward * 0;
        }
    }
}
