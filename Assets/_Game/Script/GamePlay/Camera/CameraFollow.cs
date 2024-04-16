using _Game.Script.GamePlay.Character.Player;
using _UI.Scripts.UI;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace _Game.Script.GamePlay.Camera
{
    public class CameraFollow : GameUnit
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed = 15f;
        
        public Transform Target
        {
            get => target;
            set => target = value;
        }

        void Update()
        {
            if (GameManager.IsState(GameState.GamePlay))
            {
                if (target is not null)
                {
                    Follow();
                }
            }
            
        }

        private void Follow()
        {
            TF.position = Vector3.Lerp(TF.position, target.position + offset, speed * Time.deltaTime);
        }
    }
}