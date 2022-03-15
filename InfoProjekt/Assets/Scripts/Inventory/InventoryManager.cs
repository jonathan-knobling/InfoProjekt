using System.Collections.Generic;
using System.ComponentModel;
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
            items.Add(item);
        }

        [Description("Returned ob es ein gespeichertes Item mit dem Namen dieses Items gibt")]
        public bool HasItem(Item item)
        {
            foreach (var i in items)
            {
                if (i.Name.Equals(item.Name))
                {
                    return true;
                }
            }
            return false;
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

        [Description("Removed eine bestimmte Anzahl von Items | returned false wenn es " +
                     "nicht so viele items gegeben hat wie removed werden sollten und/oder " +
                     "keine Items removed wurden. Bei erfolgreichem Removen returned die Funktion true")]
        public bool RemoveItem(Item item, int amount)
        {
            if (amount == 0)
            {
                return false;
            }
            else
            {
                int removed = 0;
                //gespeicherte items in einen neuen temporären array kopieren
                Item[] tempItems = {};
                items.CopyTo(tempItems);
                //tempItems loopen und items removen
                for(int i = 0; i < tempItems.Length; i++)
                {
                    if (removed >= amount)
                    {
                        continue;
                    }
                    if (tempItems[i].Name.Equals(item.name))
                    {
                        tempItems[i] = null;
                        removed++;
                    }
                }
                //wenn es nicht so viele items gab wie removed werden sollten
                if (removed < amount)
                {
                    return false;
                }
                //copy items back from temp array
                items.Clear();
                foreach (var i in tempItems)
                {
                    if (i != null)
                    {
                        items.Add(i);
                    }
                }
                return true;
            }
        }
    }
}