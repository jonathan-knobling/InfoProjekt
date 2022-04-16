using Environment.test;
using Tech.IO.Saves;
using UnityEngine;

namespace Environment.ObjectRegister
{
    public class EnvironmentObjectRegister: MonoBehaviour, ISaveable
    {
        [SerializeField] private EnemyDataBase enemyDataBase;
        [SerializeField] private GameObject collectableItemPrefab;

        private EnemyRegister enemyRegister;
        private ItemRegister itemRegister;

        private void Start()
        {
            enemyRegister = new EnemyRegister(enemyDataBase);
            itemRegister = new ItemRegister(collectableItemPrefab);
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

        private struct SaveData
        {
            public object EnemyRegisterData;
            public object ItemRegisterData;
        }
    }
}