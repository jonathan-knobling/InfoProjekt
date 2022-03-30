using System;
using UnityEngine;

namespace Gameplay.Inventory.Items
{
    [CreateAssetMenu(menuName = "Items/Stackable Item")]
    public class StackableItem: Item
    {
        [SerializeField] private float amount;
        
        //getter
        public float Amount => amount;

        public void AddItemAmount(float itemAmount)
        {
            amount += itemAmount;
        }

        public void RemoveItemAmount(float removeAmount)
        {
            amount -= removeAmount;
        }

        public override void RequestAddItem(IItemContainer container)
        {
            container.AddItem(this);
        }

        public override void RequestDropItem(IItemContainer container)
        {
            container.DropItem(this, amount);
        }
    }
}