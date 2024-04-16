using _Game.Script.GamePlay.Character.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Script.GamePlay.Camera
{
    public class CameraManager : Singleton<CameraManager>
    {
        [FormerlySerializedAs("cameraFolow")] [FormerlySerializedAs("cameraFlow")] [SerializeField] private CameraFollow cameraFollow;
        
        public CameraFollow GetCamera => cameraFollow;
        public void SetPosition(Vector3 position)
        {
            cameraFollow.TF.position = position;
        }
    }
}