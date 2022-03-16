using System.Collections.Generic;
using System.ComponentModel;
using Inventory.Items;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager: MonoBehaviour
    {
        public static InventoryManager Instance;
        
        private List<Item> items;

        private void Awake()
        {
            Instance = this;
        }

        [Description("Add Item to the Inventory")]
        public void AddItem(Item item)
        {
            //wenn das item stackable ist
            if (item is StackableItem)
            {
                foreach (var i in items)
                {
                    //wenn es das item schon gibt
                    if (i.name.Equals(item.Name))
                    {
                        StackableItem s1 = (StackableItem) i;
                        StackableItem s2 = (StackableItem) item;
                        //den amount erhöhen
                        s1.AddItemAmount(s2.Amount);
                        return;
                    }
                }
            }
            //wenn es das item noch nicht gibt oder es nicht stackable ist
            items.Add(item);
        }

        [Description("Returned ob es ein gespeichertes Item mit dem Namen dieses Items gibt")]
        public bool HasItem(Item item)
        {
            return HasItem(item.Name);
        }
        
        [Description("Returned ob es ein gespeichertes Item mit dem Name gibt")]
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

        [Description("Returned ob es minAmount von stackableItem gibt")]
        public bool HasItem(Item item, float minAmount)
        {
            if (item is StackableItem)
            {
                foreach (var i in items)
                {
                    if (i.Name.Equals(item.Name))
                    {
                        StackableItem stackableItem = (StackableItem) i;
                        if (stackableItem.Amount >= minAmount)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        [Description("Removed einen bestimmten amount von einem Item | " +
                     "returned als bool ob das removen erfolgreich war")]
        public bool RemoveItem(Item item, int amount)
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
                    if (item is StackableItem)
                    {
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
            }
            
            return false;
        }
    }
}