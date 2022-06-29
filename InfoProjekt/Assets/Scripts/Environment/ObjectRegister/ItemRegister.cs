using System;
using System.Collections.Generic;
using Gameplay.Inventory;
using Tech.IO.Saves;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util.Serialization;
using Object = UnityEngine.Object;

namespace Environment.ObjectRegister
{
    public class ItemRegister: ISaveable
    {
        private readonly GameObject collectableItemPrefab;
        
        private HashSet<CollectableItem> items;

        public ItemRegister(GameObject collectableItemPrefab)
        {
            this.collectableItemPrefab = collectableItemPrefab;
        }

        public void RegisterItem(CollectableItem item)
        {
            if (!items.Contains(item)) items.Add(item);
        }

        public void RemoveItem(CollectableItem item)
        {
            if (items.Contains(item)) items.Remove(item);
        }
        
        
        //saving
        public object SerializeComponent()
        {
            List<SaveData> saveData = new List<SaveData>();
            string activeScene = SceneManager.GetActiveScene().name;

            foreach (var item in items)
            {
                saveData.Add(new SaveData()
                {
                    Scene = activeScene,
                    ItemData = item.SerializeComponent(),
                    Transform = new SerializeableTransform(item.transform)
                });
            }
            
            return saveData;
        }

        public void ApplySerializedData(object serializedData)
        {
            var data = (List<SaveData>) serializedData;
            string activeScene = SceneManager.GetActiveScene().name;

            foreach (var saveData in data)
            {
                if(!saveData.Scene.Equals(activeScene)) continue;

                var item = Object.Instantiate(
                    collectableItemPrefab, 
                    saveData.Transform.GetPosition(),
                    saveData.Transform.GetRotation());

                item.GetComponent<CollectableItem>().ApplySerializedData(saveData.ItemData);
            }
        }

        [Serializable]
        private struct SaveData
        {
            public string Scene;
            public object ItemData;
            public SerializeableTransform Transform;
        }
    }
}