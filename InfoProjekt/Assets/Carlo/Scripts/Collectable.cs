using System;
using Gameplay.Inventory;
using Gameplay.Inventory.Items;
using Tech.IO.PlayerInput;
using UI.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Util.EventArgs;

namespace Assets.Carlo.Scripts
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private InputChannelSO inputChannel;
        [SerializeField] private float interactionRadius;
        [SerializeField] private LayerMask interactionLayer;
        [SerializeField] private Item item;
        [SerializeField] private UIChannelSO uiChannel;
        [SerializeField] private GameObject pickUpEffect;
        private InteractionBar pickUpInteraction;
        
            
        private Label text;
        void Start()
        {
            inputChannel.OnInteractButtonPressed += InteractButtonPressed;
            pickUpInteraction = new InteractionBar(0.7f, uiChannel);
            pickUpInteraction.OnProgressBarOver += Interact;
        }

        private void InteractButtonPressed()
        {
            if (Physics2D.OverlapCircle(transform.position, interactionRadius, interactionLayer))
            {
                return;
            }
        }

        private void Interact()
        {
            CreateParticles();
            Destroy(gameObject);
            InventoryManager.Instance.AddItem(item);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            text = new Label();
            text.text = "Press F to pick up!";
            text.style.fontSize = 40;
            uiChannel.RequestAddUIVisualElement(new UIEventArgs(text, null, UIType.Prompt));
        }
        private void OnTriggerExit2D(Collider2D col)
        {
            uiChannel.RequestRemoveUIVisualElement(text);
        }

        private void CreateParticles()
        {
         var particle = Instantiate(pickUpEffect, transform.position, transform.rotation);
         particle.GetComponent<ParticleSystem>().Play();
        }

        void OnTriggerStay2D(Collider2D other)
        {
            pickUpInteraction.Update();
        }
    }
    
}
