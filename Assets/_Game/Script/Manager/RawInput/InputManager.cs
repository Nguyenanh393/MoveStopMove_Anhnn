using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Script.RawInput
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