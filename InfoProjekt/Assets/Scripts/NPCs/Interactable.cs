using IO;
using UnityEngine;

namespace NPCs
{
    public abstract class Interactable: MonoBehaviour
    {
        [SerializeField] protected InputChannelSO inputChannel;
        [SerializeField] protected int interactionRadius;
        [SerializeField] protected LayerMask playerMask;

        public abstract void Interact();
        public abstract void Init();
        
        private void Start()
        {
            Init();    
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
    }
}