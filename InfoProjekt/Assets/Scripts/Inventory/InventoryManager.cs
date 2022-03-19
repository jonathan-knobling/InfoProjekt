using System.Collections.Generic;
using Inventory.Items;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager: MonoBehaviour, IItemContainer
    {
        public static InventoryManager Instance;
        
        [SerializeField] private List<Item> items;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            if (items == null)
            {
                items = new List<Item>();
            }
        }

        public void AddItem(Item item)
        {
            item.RequestAddItem(this);
        }

        public void AddItem(NonStackableItem item)
        {
            items.Add(item);
        }

        public void AddItem(StackableItem item)
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
                    return;
                }
            }
            items.Add(item);
        }

        public bool HasItem(NonStackableItem item)
        {
            return HasItem(item.Name);
        }
        
        public bool HasItem(string itemName)
        {
            foreach (var i in items)
            {
                if (i.Name.Equals(itemName))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasItem(StackableItem item, float minAmount)
        {
            foreach (var i in items)
            {
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
            if (amount == 0)
            {
                return false;
            }

            //list von hinten iteraten damit ich evtl items[i] sicher removen kann
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Name.Equals(item.Name))
                {
                    //Item zu Stackable item casten
                    StackableItem stackableItem = (StackableItem) items[i];
                    if (stackableItem.Amount > amount)
                    {
                            stackableItem.RemoveItemAmount(amount);
                            return true;
                    }
                    else if (stackableItem.Amount.Equals(amount))
                    {
                        items.RemoveAt(i);
                        return true;
                    }
                }
                else
                {
                    items.RemoveAt(i);
                }
            }

            return false;
        }

        public bool RemoveItem(NonStackableItem item)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Name.Equals(item.Name))
                {
                    items.RemoveAt(i);
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