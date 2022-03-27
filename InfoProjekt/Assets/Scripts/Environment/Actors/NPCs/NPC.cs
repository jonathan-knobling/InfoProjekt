using Gameplay.Dialogue;
using Gameplay.Dialogue.Util;
using Tech.IO;
using UnityEngine;

namespace Environment.Actors.NPCs
{
    public abstract class NPC: Actor, IInteractable
    {
        [Header("Tech Stuff")]
        [SerializeField] protected DialogueChannelSO dialogueChannel;
        [SerializeField] protected InputChannelSO inputChannel;

        [Header("Interaction Stuff")]
        [SerializeField] protected float interactionRadius = 2f;
        [SerializeField] protected LayerMask interactionLayers;
        
        [Header("NPC Stuff")]
        [SerializeField] protected Dialogue greetDialogue;

        public void Start()
        {
            inputChannel.OnInteractButtonPressed += OnInteractButtonPressed;
        }

        public virtual void Interact()
        {
            dialogueChannel.RequestDialog(greetDialogue);
        }

        protected virtual void OnInteractButtonPressed()
        {
            if (Physics2D.OverlapCircle(transform.position, interactionRadius, interactionLayers))
            {
                Interact();
                Debug.Log("interact");
                //show "press f to interact" oder so �hnlich :)
            }
        }
    }
}