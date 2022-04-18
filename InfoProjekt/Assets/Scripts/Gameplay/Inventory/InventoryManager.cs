using Gameplay.Inventory.Items;
using UnityEngine;

namespace Gameplay.Inventory
{
    public class InventoryManager: MonoBehaviour, IItemContainer
    {
        public static IItemContainer ItemContainerInstance;

        [SerializeField] private int inventoryCapacity = 36;
        [SerializeField] private int hotbarCapacity = 9;

        //alle items
        private Item[] items;

        //hotbar is first 9 elements of items array
        public Item[] hotbarItems => items[..(hotbarCapacity-1)];
        
        private void Awake()
        {
            ItemContainerInstance = this;
        }

        private void Start()
        {
            items = new Item[inventoryCapacity];
        }

        public int GetFirstEmptySlot()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(null)) return i;
            }

            return -1;
        }

        public bool DropSlot(int slot)
        {
            if (items[slot].Equals(null)) return false;
            
            //drop item
            return true;
        }

        public void RemoveSlot(int slot)
        {
            items[slot] = null;
        }

        public Item GetSlot(int slut) // :)
        {
            return items[slut];
        }

        public bool TryAddItem(Item item)
        {
            return item.RequestAddItem(this);
        }
        
        public bool TryAddItem(StackableItem item)
        {
            foreach (var i in items)
            {
                //wenn es das item schon gibt
                if (i.name.Equals(item.Name))
                {
                    //kann sein das es nicht funktioniert wegen dem casten
                    StackableItem stackableItem = (StackableItem) i;
                    //den amount erhöhen
                    stackableItem.AddItemAmount(item.Amount);
                    return true;
                }
            }

            return TryAddItem(item, GetFirstEmptySlot());
        }

        public bool TryAddItem(NonStackableItem item)
        {
            return TryAddItem(item, GetFirstEmptySlot());
        }

        public bool TryAddItem(Item item, int slot)
        {
            return item.RequestAddItem(this,slot);
        }

        public bool TryAddItem(StackableItem item, int slot)
        {
            try
            {
                if (items[slot].Equals(null)) return false;
            }
            catch
            {
                Debug.LogWarning("Trying to access inventory item slot but index is out of bounds: " + slot);
                return false;
            }

            items[slot] = item;
            return true;
        }

        public bool TryAddItem(NonStackableItem item, int slot)
        {
            try
            {
                if (items[slot].Equals(null)) return false;
            }
            catch
            {
                Debug.LogWarning("Trying to access inventory item slot but index is out of bounds: " + slot);
                return false;
            }

            items[slot] = item;
            return true;
        }

        public bool HasItem(NonStackableItem item)
        {
            return HasItem(item.Name);
        }
        
        public bool HasItem(string itemName)
        {
            foreach (var i in items)
            {
                if (i.Equals(null)) continue;
                
                if (i.Name.Equals(itemName)) return true;
            }
            return false;
        }

        public bool HasItem(StackableItem item, float minAmount)
        {
            foreach (var i in items)
            {
                if (i.Equals(null)) continue;
                
                if (i.Name.Equals(item.Name))
                {
                    //Item zu Stackable item casten
                    StackableItem stackableItem = (StackableItem) i;
                    if (stackableItem.Amount >= minAmount)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public bool RemoveItem(StackableItem item, float amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(null)) continue;
                
                if (items[i].Name.Equals(item.Name))
                {
                    //Item zu Stackable item casten
                    StackableItem stackableItem = (StackableItem) items[i];
                    if (stackableItem.Amount > amount)
                    {
                            stackableItem.RemoveItemAmount(amount);
                            return true;
                    }
                    if (stackableItem.Amount <= amount)
                    {
                        items[i] = null;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool RemoveItem(NonStackableItem item)
        {
            for (int i = items.Length - 1; i >= 0; i--)
            {
                if (items[i].Name.Equals(item.Name))
                {
                    items[i] = null;
                }
            }

            return false;
        }

        public void DropItem(Item item)
        {
            item.RequestDropItem(this);
        }

        public void DropItem(NonStackableItem item)
        {
            //RemoveItem(item);
            //anscheinend effizienter
            //var transform1 = transform;
            //Instantiate(item.DropItem, transform1.position, transform1.rotation);
        }

        //overloaden = op
        public void DropItem(StackableItem item, float amount)
        {
            //RemoveItem(item, amount);
            //var transform1 = transform;
            // Instantiate(item.DropItem, transform1.position, transform1.rotation);
        } 
    }
}