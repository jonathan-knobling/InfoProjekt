using System;
using UnityEngine;

namespace Gameplay.Inventory.ItemSaving
{
    [CreateAssetMenu(menuName = "Channels/Item Save Channel")]
    public class ItemSaveChannelSO: ScriptableObject
    {
        public event Action<CollectableItem> OnAddDropItem;
        public event Action<CollectableItem> OnRemoveDropItem;

        public void RequestAddDropItem(CollectableItem item)
        {
            OnAddDropItem?.Invoke(item);
        }

        public void RequestRemoveDropItem(CollectableItem item)
        {
            OnRemoveDropItem?.Invoke(item);
        }
    }
}