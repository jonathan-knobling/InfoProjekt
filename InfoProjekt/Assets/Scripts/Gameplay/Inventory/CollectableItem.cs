using Gameplay.Inventory.Items;
using UnityEngine;
using Util;

namespace Gameplay.Inventory
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class CollectableItem: MonoBehaviour
    {
        [SerializeField] public Item item;
        private const float DespawnTimeSeconds = 300f;
        
        private Timer timer;
        
        private void Start()
        {
            timer = new Timer(DespawnTimeSeconds);
            timer.OnElapsed += OnTimerOver;
            
            if (item == null)
            {
                Debug.Log("Item is null");
                return;
            }
            GetComponent<SpriteRenderer>().sprite = item.Sprite;
        }
        
        private void Update()
        {
            timer.Update();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("trigger enter");
            if (col.GetComponent<InventoryManager>() != null)
            {
                if (item == null)
                {
                    Debug.Log("TriggerEnter but Item is null");
                    return;
                }
                col.GetComponent<InventoryManager>().AddItem(item);
                Destroy(this);
            }
        }
        
        private void OnTimerOver()
        {
            Destroy(this);
        }
    }
}