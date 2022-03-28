using Gameplay.Inventory;
using Gameplay.Inventory.Items;
using Tech.IO;
using UI;
using UnityEngine;
using UnityEngine.UIElements;


public class Collectable : MonoBehaviour
{
    [SerializeField] private InputChannelSO inputChannel;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private Item item;
    [SerializeField] private UIChannelSO uiChannel;
    private Label text;
    void Start()
    {
        inputChannel.OnInteractButtonPressed += InteractButtonPressed;
    }
    
    private void InteractButtonPressed()
    {
        if (Physics2D.OverlapCircle(transform.position, interactionRadius, interactionLayer))
        {
            Interact();
        }
    }

    private void Interact()
    {
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
        text.transform.position = new Vector2(900, 900);
        text.style.fontSize = 40;
        uiChannel.RequestAddUIVisualElement(text);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        uiChannel.RequestRemoveUIVisualElement(text);
    }
}
