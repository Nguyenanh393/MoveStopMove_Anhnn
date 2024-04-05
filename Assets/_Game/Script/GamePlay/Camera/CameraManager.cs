using _Game.Script.GamePlay.Character.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Script.GamePlay.Camera
{
    public class CameraManager : Singleton<CameraManager>
    {
        [SerializeField] private CameraFlow cameraFlow;
        
        public CameraFlow GetCamera => cameraFlow;
        public void SetPosition(Vector3 position)
        {
            cameraFlow.TF.position = position;
        }
    }
}