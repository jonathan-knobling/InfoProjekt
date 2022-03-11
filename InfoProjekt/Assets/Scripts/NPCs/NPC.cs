using NPCs.Dialogue;
using UnityEngine;

namespace NPCs
{
    public class NPC: Interactable
    {
        [SerializeField] private DialogueChannelSO dialogueChannel;
        [SerializeField] private Dialogue.Util.Dialogue greetDialogue;

        public override void Interact()
        {
            dialogueChannel.RequestDialog(greetDialogue);
        }

        protected override void Update()
        {
            if (Physics2D.OverlapCircle(transform.position, interactionRadius, playerMask))
            {
                if (Input.GetButtonDown("Interact"))
                {
                    Interact();
                    Debug.Log("interact");
                }
                //show "press f to interact" oder so ähnlich :)
            }
        }
    }
}