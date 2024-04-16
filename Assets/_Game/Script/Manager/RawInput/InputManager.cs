using System;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Script.Manager.RawInput
{
    public class InputManager : Singleton<InputManager>
    {
        [SerializeField] private FloatingJoystick floatingJoystick;

        public FloatingJoystick GetJoystick => floatingJoystick;

        private void Update()
        {
            // if (!GameManager.IsState(GameState.GamePlay)) return;
            // if (HasJoystick())
            // {
            //     MoveJoystick();
            // }
        }

        public void FindJoystick()
        {
            if (floatingJoystick != null)
            {
                return;
            }
            floatingJoystick = FindObjectOfType<FloatingJoystick>();
        }

        public bool HasJoystick()
        {
            //MoveJoystick();
            return floatingJoystick.Direction != Vector2.zero;
        }
    }
}