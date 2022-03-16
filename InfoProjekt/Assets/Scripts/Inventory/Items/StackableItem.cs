using UnityEngine;

namespace Inventory.Items
{
    [CreateAssetMenu(menuName = "Items/Stackable Item")]
    public sealed class StackableItem: Item
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
    }
}