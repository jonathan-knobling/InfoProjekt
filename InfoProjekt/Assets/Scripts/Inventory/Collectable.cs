using Inventory.Items;
using UnityEngine;

namespace Inventory
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Collectable: MonoBehaviour
    {
        [SerializeField] public Item item;

        private void Start()
        {
            if (item == null)
            {
                Debug.Log("Item is null");
                return;
            }
            GetComponent<SpriteRenderer>().sprite = item.Sprite;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<InventoryManager>() != null)
            {
                if (item == null)
                {
                    Debug.Log("TriggerEnter but Item is null");
                    return;
                }
                col.GetComponent<InventoryManager>().AddItem(item);
            }
        }
    }
}