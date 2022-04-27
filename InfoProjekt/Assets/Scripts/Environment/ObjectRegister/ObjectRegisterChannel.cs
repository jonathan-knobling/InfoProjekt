using System;
using Gameplay.Inventory;
using UnityEngine;

namespace Environment.ObjectRegister
{
    public class ObjectRegisterChannel
    {
        public int currentMobCap { get; set; }
        
        public event Action<GameObject> OnRequestRegisterEnemy;
        public event Action<GameObject> OnRequestRemoveEnemy;
        public event Action<CollectableItem> OnRequestRegisterCollectableItem;
        public event Action<CollectableItem> OnRequestRemoveCollectableItem;
        
        public void RequestRegisterEnemy(GameObject enemy)
        {
            OnRequestRegisterEnemy?.Invoke(enemy);
        }

        public void RequestRemoveEnemy(GameObject enemy)
        {
            OnRequestRemoveEnemy?.Invoke(enemy);
        }

        public void RequestRegisterCollectableItem(CollectableItem item)
        {
            OnRequestRegisterCollectableItem?.Invoke(item);
        }

        public void RequestRemoveCollectableItem(CollectableItem item)
        {
            OnRequestRemoveCollectableItem?.Invoke(item);
        }
    }
}