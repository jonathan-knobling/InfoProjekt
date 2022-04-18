using System;
using Environment.ObjectRegister;
using Gameplay.Inventory.Items;
using Tech.IO.Saves;
using UnityEngine;
using Util;

namespace Gameplay.Inventory
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class CollectableItem: MonoBehaviour, ISaveable
    {
        [SerializeField] public Item item;
        [SerializeField] private ItemDataBase itemDataBase;
        private const float DespawnTimeSeconds = 300f;
        
        private Timer timer;
        
        private void Start()
        {
            timer = new Timer(DespawnTimeSeconds);
            timer.OnElapsed += OnTimerOver;
            
            if (item == null)
            {
                Debug.Log("item is null");
                return;
            }
            GetComponent<SpriteRenderer>().sprite = item.Sprite;
        }

        private void Update()
        {
            timer.Update();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("trigger enter");
            if (col.GetComponent<InventoryManager>() != null)
            {
                if (item == null)
                {
                    Debug.Log("TriggerEnter but item is null");
                    return;
                }
                col.GetComponent<IItemContainer>().TryAddItem(item);
                Destroy(gameObject);
            }
        }
        
        private void OnTimerOver()
        {
            Destroy(gameObject);
        }
        

        //Saving
        public object SerializeComponent()
        {
            return new SaveData()
            {
                timeUntilDespawn = timer.ElapsedTime,
                itemName = item.Name
            };
        }

        public void ApplySerializedData(object serializedData)
        {
            var data = (SaveData) serializedData;
            item = itemDataBase.GetItem(data.itemName);
            timer = new Timer(DespawnTimeSeconds - data.timeUntilDespawn);
        }

        [Serializable]
        private struct SaveData
        {
            public float timeUntilDespawn;
            public string itemName;
        }
    }
}