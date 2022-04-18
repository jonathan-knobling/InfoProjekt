using System;
using UnityEngine;

namespace Gameplay.Inventory.Items
{
    [CreateAssetMenu(menuName = "Items/Non Stackable Item")]
    public class NonStackableItem: Item
    {
        public override bool RequestAddItem(IItemContainer container, int slot)
        {
            return container.TryAddItem(this, slot);
        }

        public override bool RequestAddItem(IItemContainer container)
        {
            return container.TryAddItem(this);
        }

        public override void RequestDropItem(IItemContainer container)
        {
            container.DropItem(this);
        }
    }
}