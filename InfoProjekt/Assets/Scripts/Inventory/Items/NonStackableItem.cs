using UnityEngine;

namespace Inventory.Items
{
    [CreateAssetMenu(menuName = "Items/Non Stackable Item")]
    public class NonStackableItem: Item
    {
        public override void RequestAddItem(IItemContainer container)
        {
            container.AddItem(this);
        }

        public override void RequestDropItem(IItemContainer container)
        {
            container.DropItem(this);
        }
    }
}