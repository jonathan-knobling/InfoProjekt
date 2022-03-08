using UnityEngine;

namespace NPCs
{
    public abstract class Interactable: MonoBehaviour
    {
        [SerializeField] protected int interactionRadius;

        public abstract void Interact();

        protected virtual void Update()
        {
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
    }
}