using UnityEngine;

namespace _Game.Script.Manager.RawInput
{
    public class InputManager : Singleton<InputManager>
    {
        [SerializeField] private VariableJoystick variableJoystick;

        public VariableJoystick GetJoystick => variableJoystick;

        public void FindJoystick()
        {
            if (variableJoystick != null)
            {
                return;
            }
            variableJoystick = FindObjectOfType<VariableJoystick>();
        }

        public bool HasJoystick()
        {
            return variableJoystick.Direction != Vector2.zero;
        }
    }
}