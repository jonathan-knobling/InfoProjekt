using UnityEngine;

namespace NPCs
{
    public class NPC: Interactable
    {
        public override void Interact()
        {
            
        }

        protected override void Update()
        {
            if (Physics2D.OverlapCircle(transform.position, interactionRadius).name.Equals("Player"))
            {
                if (Input.GetButtonDown("Interaction"))
                {
                    Interact();
                }
                //show "press f to interact" oder so ähnlich :)
            }
        }
    }
}