using Environment;
using Gameplay.Dialogue.Util;
using Tech;
using UnityEngine;
using UnityEngine.Serialization;

namespace Actors.NPCs
{
    public class NPC: Actor, IInteractable
    {
        [Header("Tech Stuff")] 
        [SerializeField] private EventChannelSO eventChannel;

        [Header("Interaction Stuff")]
        [SerializeField] private float interactionRadius = 2f;
        [SerializeField] private LayerMask interactionLayers;
        [SerializeField] private string npcID;
        private GameObject player;
        
        [Header("NPC Stuff")]
        [SerializeField] private Dialogue greetDialogue;

        public void Start()
        {
            GameObject.Find("Player");
            eventChannel.InputChannel.OnInteractButtonPressed += OnInteractButtonPressed;
        }

        public void Interact()
        {
            TurnToPlayer();
            eventChannel.DialogueChannel.RequestDialog(greetDialogue);
    
        }

        private void OnInteractButtonPressed()
        {
            if (Physics2D.OverlapCircle(transform.position, interactionRadius, interactionLayers))
            {
                Debug.Log("interact");
                Interact();
                //show "press f to interact" oder so �hnlich :)
            }
        }

        private void TurnToPlayer()
        {
            Vector3 relativePos = player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
        }
    }
}