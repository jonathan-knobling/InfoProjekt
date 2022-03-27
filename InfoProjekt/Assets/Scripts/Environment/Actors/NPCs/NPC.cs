using Gameplay.Dialogue;
using UnityEngine;

namespace Environment.Actors.NPCs
{
    public class NPC: Interactable
    {
        [SerializeField] private DialogueChannelSO dialogueChannel;
        [SerializeField] private global::Gameplay.Dialogue.Util.Dialogue greetDialogue;

        public override void Interact()
        {
            dialogueChannel.RequestDialog(greetDialogue);
        }

        public override void Init()
        {
            inputChannel.OnInteractButtonPressed += OnInteractButtonPressed;
        }
        
        private void OnInteractButtonPressed()
        {
            if (Physics2D.OverlapCircle(transform.position, interactionRadius, playerMask))
            {
                Interact();
                Debug.Log("interact");
                //show "press f to interact" oder so ähnlich :)
            }
        }
    }
}