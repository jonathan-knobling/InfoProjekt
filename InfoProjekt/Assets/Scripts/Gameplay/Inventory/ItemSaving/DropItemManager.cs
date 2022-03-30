using System;
using System.Collections.Generic;
using Tech;
using Tech.IO.Saves;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util.Serialization;

namespace Gameplay.Inventory.ItemSaving
{
    public class DropItemManager: MonoBehaviour, IIdentifiable
    {
        [SerializeField] private List<CollectableItem> dropItems;
        [SerializeField] private ItemSaveChannelSO itemChannel;
        [SerializeField] private SaveChannelSO saveChannel;
        [SerializeField] private GameObject dropItemPrefab;
        [SerializeField] private string id = "DropItemManager";

        public string ID => id;

        private void Start()
        {
            itemChannel.OnAddDropItem += AddItem;
            itemChannel.OnRemoveDropItem += RemoveItem;

            saveChannel.OnLoad += LoadItems;
            
            SceneManager.activeSceneChanged += SceneChanged;
        }

        private void AddItem(CollectableItem item)
        {
            dropItems.Add(item);
        }

        private void RemoveItem(CollectableItem item)
        {
            dropItems.Remove(item);
        }
        
        private void SceneChanged(Scene arg0, Scene arg1)
        {
            SaveItems();
        }

        [ContextMenu("Save")]
        private void SaveItems()
        {
            SaveData data = new SaveData()
            {
                Items = new object[dropItems.Count],
                transforms = new SerializeableTransform[dropItems.Count]
            };

            for (int i = 0; i < data.Items.Length; i++)
            {
                data.Items[i] = dropItems[i].SerializeComponent();
                data.transforms[i] = new SerializeableTransform(dropItems[i].transform);
            }

            saveChannel.Save(ID, data);
        }

        [Serializable]
        private struct SaveData
        {
            public object[] Items;
            public SerializeableTransform[] transforms;
        }

        private void LoadItems(Dictionary<string, object> serializedData)
        {
            serializedData.TryGetValue(ID, out var value);
            
            if (value != null)
            {
                var data = (SaveData) value;
                for (int i = 0; i < data.Items.Length; i++)
                {
                    //instantiate prefab and apply saved position and rotation
                    Instantiate(dropItemPrefab, data.transforms[i].GetPosition(), 
                            data.transforms[i].GetRotation())
                        //get collectable item component and apply saved data
                        .GetComponent<CollectableItem>().ApplySerializedData(data.Items[i]);   
                }
            }
        }
    }
}