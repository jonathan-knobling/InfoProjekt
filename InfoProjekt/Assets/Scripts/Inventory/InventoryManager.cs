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

        public void AddItem(Item item)
        {
            foreach (var i in items)
            {
                if (i.name.Equals(item.Name))
                {
                    i.AddItemAmount(item.Amount);
                    return;
                }
            }
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
            return HasItem(itemName, 0);
        }

        [Description("Returned ob es minAmount von item gibt")]
        public bool HasItem(Item item, float minAmount)
        {
            return HasItem(item.Name, minAmount);
        }

        [Description("Returned ob es minAmount vom itemName gibt")]
        public bool HasItem(string itemName, float minAmount)
        {
            foreach (var i in items)
            {
                if (i.Name.Equals(itemName))
                {
                    if (i.Amount >= minAmount)
                    {
                        return true;
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
                    if (items[i].Amount > amount)
                    {
                        items[i].RemoveItemAmount(amount);
                        return true;
                    }
                    else if (items[i].Amount.Equals(amount))
                    {
                        items.RemoveAt(i);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}