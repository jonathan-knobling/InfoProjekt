using Environment;
using Gameplay.Dialogue.Util;
using Tech;
using UnityEngine;

namespace Actors.NPCs
{
    public class NPC: Actor, IInteractable
    {
        [Header("Tech Stuff")] 
        [SerializeField]
        private EventChannelSO eventChannel;

        [Header("Interaction Stuff")]
        [SerializeField]
        private float interactionRadius = 2f;
        [SerializeField] private LayerMask interactionLayers;
        
        [Header("NPC Stuff")]
        [SerializeField]
        private Dialogue greetDialogue;

        public void Start()
        {
            eventChannel.InputChannel.OnInteractButtonPressed += OnInteractButtonPressed;
        }

        public void Interact()
        {
            eventChannel.DialogueChannel.RequestDialog(greetDialogue);
        }

        private void OnInteractButtonPressed()
        {
            if (Physics2D.OverlapCircle(transform.position, interactionRadius, interactionLayers))
            {
                Debug.Log("interact");
                Interact();
                //show "press f to interact" oder so ähnlich :)
            }
        }
    }
}