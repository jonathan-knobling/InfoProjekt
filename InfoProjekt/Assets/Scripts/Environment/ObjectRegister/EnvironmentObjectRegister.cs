using System;
using Actors.Enemies;
using Gameplay.Inventory;
using Tech;
using Tech.IO.Saves;
using UnityEngine;

namespace Environment.ObjectRegister
{
    public class EnvironmentObjectRegister: MonoBehaviour, ISaveable
    {
        [SerializeField] private EventChannelSO eventChannel;
        [SerializeField] private EnemyDataBase enemyDataBase;
        [SerializeField] private GameObject collectableItemPrefab;

        private EnemyRegister enemyRegister;
        private ItemRegister itemRegister;

        private void Start()
        {
            enemyRegister = new EnemyRegister(enemyDataBase);
            itemRegister = new ItemRegister(collectableItemPrefab);

            eventChannel.ObjectRegisterChannel.OnRequestRegisterEnemy += RegisterEnemy;
            eventChannel.ObjectRegisterChannel.OnRequestRemoveEnemy += RemoveEnemy;
            eventChannel.ObjectRegisterChannel.OnRequestRegisterCollectableItem += RegisterItem;
            eventChannel.ObjectRegisterChannel.OnRequestRemoveCollectableItem += RemoveItem;
        }

        private void Update()
        {
            eventChannel.ObjectRegisterChannel.currentMobCap = enemyRegister.CurrentMobCap;
        }

        private void RegisterEnemy(GameObject enemy)
        {
            if (!enemy.TryGetComponent(typeof(EnemyStats), out _)) return;
            enemyRegister.RegisterEnemy(enemy);
        }

        private void RemoveEnemy(GameObject enemy)
        {
            if (!enemy.TryGetComponent(typeof(EnemyStats), out _)) return;
            enemyRegister.RemoveEnemy(enemy);
        }

        private void RegisterItem(CollectableItem item)
        {
            itemRegister.RegisterItem(item);
        }

        private void RemoveItem(CollectableItem item)
        {
            itemRegister.RemoveItem(item);
        }

        public object SerializeComponent()
        {
            return new SaveData()
            {
                EnemyRegisterData = enemyRegister.SerializeComponent(),
                ItemRegisterData = itemRegister.SerializeComponent()
            };
        }

        public void ApplySerializedData(object serializedData)
        {
            var data = (SaveData) serializedData;
            enemyRegister.ApplySerializedData(data.EnemyRegisterData);
            itemRegister.ApplySerializedData(data.ItemRegisterData);
        }

        [Serializable]
        private struct SaveData
        {
            public object EnemyRegisterData;
            public object ItemRegisterData;
        }
    }
}