using System.Collections.Generic;
using System.Linq;
using Gameplay.Inventory.Items;
using UnityEngine;

namespace Gameplay.Inventory
{
    [CreateAssetMenu(menuName = "Databases/Item Database")]
    public class ItemDataBase: ScriptableObject
    {
        [SerializeField] private List<Item> itemList;
        private Dictionary<string, Item> Items => itemList.ToDictionary(item => item.Name);

        public Item GetItem(string itemName)
        {
            return Items[itemName];
        }
    }
}