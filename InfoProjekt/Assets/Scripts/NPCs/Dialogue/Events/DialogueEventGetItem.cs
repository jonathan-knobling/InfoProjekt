using Inventory;
using Inventory.Items;
using UnityEngine;

namespace NPCs.Dialogue.Events
{
    [CreateAssetMenu(menuName = "Dialogue/Events/Get Item")]
    public class DialogueEventGetItem: DialogueEvent
    {

        [SerializeField] private Item item;
        
        public override void Invoke()
        {
            InventoryManager.Instance.AddItem(item);
        }
    }
}