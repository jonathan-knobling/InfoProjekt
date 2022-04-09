using Gameplay.Inventory;
using Gameplay.Inventory.Items;
using UnityEngine;

namespace Gameplay.Dialogue.Events
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