using Inventory;
using Inventory.Items;
using IO;
using NPCs;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PickUpOre : MonoBehaviour
{
    public InputChannelSO inputChannel;
    private bool touched;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private Item item;

    void Start()
    {
        inputChannel.InteractButtonPressed += onUseButtonPressed;
    }
    
    private void onUseButtonPressed()
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
}
