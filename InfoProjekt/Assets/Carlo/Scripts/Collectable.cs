using Gameplay.Inventory;
using Gameplay.Inventory.Items;
using Tech;
using UI.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Util.EventArgs;

namespace Carlo.Scripts
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private EventChannelSO eventChannel;
        [SerializeField] private float interactionRadius;
        [SerializeField] private LayerMask interactionLayer;
        [SerializeField] private Item item;
        [SerializeField] private GameObject pickUpEffect;
        private InteractionBar pickUpInteraction;
        private GameObject particle;
        
            
        private Label text;
        void Start()
        {
            eventChannel.InputChannel.OnInteractButtonPressed += InteractButtonPressed;
            pickUpInteraction = new InteractionBar(0.7f, eventChannel);
            pickUpInteraction.OnProgressBarOver += Interact;
            pickUpInteraction.StartEffect += CreateParticles;
            pickUpInteraction.StopEffect += StopParticles;
            particle = Instantiate(pickUpEffect, transform.position, transform.rotation);
        }

        private void InteractButtonPressed()
        {
            if (Physics2D.OverlapCircle(transform.position, interactionRadius, interactionLayer))
            {
                
            }
        }

        private void Interact()
        {
            Destroy(particle);
            Destroy(gameObject);
            InventoryManager.ItemContainerInstance.TryAddItem(item);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            text = new Label
            {
                text = "Press F to pick up!",
                style = {fontSize = 40}
            };
            eventChannel.UIChannel.RequestAddUIVisualElement(new UIEventArgs(text, null, UIType.Prompt));
        }
        private void OnTriggerExit2D(Collider2D col)
        {
            eventChannel.UIChannel.RequestRemoveUIVisualElement(text);
        }

        private void CreateParticles()
        {
            particle.GetComponent<ParticleSystem>().Play();
        }

        private void StopParticles()
        {
            particle.GetComponent<ParticleSystem>().Stop();
        }

        void OnTriggerStay2D(Collider2D other)
        {
            pickUpInteraction.Update();
        }
    }
    
}
