using _Game.Script.OtherOpti;
using UnityEngine;

namespace _Game.Script.GamePlay.Camera
{
    public class CameraSight : MonoBehaviour
    {
        [SerializeField] private Material transparentMaterial;
        [SerializeField] private Material defaultMaterial;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constances.ColliderTag.WALL))
            {
                MeshRenderer wallRenderer = Cache<MeshRenderer>.GetComponent(other);
                wallRenderer.material = transparentMaterial;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Constances.ColliderTag.WALL))
            {
                MeshRenderer wallRenderer = Cache<MeshRenderer>.GetComponent(other);
                wallRenderer.material = defaultMaterial;
            }
        }
    }
}
