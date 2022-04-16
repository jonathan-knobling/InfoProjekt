using System.Collections.Generic;
using Actors.Enemies;
using Environment.test;
using Tech.IO.Saves;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util.Serialization;

namespace Environment.ObjectRegister
{
    public class EnemyRegister: ISaveable
    {
        private readonly EnemyDataBase enemyDataBase;

        private HashSet<GameObject> enemies;

        public EnemyRegister(EnemyDataBase dataBase)
        {
            enemyDataBase = dataBase;
        }

        public void RegisterEnemy(GameObject enemy)
        {
            if(!enemies.Contains(enemy)) enemies.Add(enemy);
        }

        public void RemoveEnemy(GameObject enemy)
        {
            if (enemies.Contains(enemy)) enemies.Remove(enemy);
        }
        
        
        //saving
        public object SerializeComponent()
        {
            List<SaveData> saveData = new List<SaveData>();
            string activeScene = SceneManager.GetActiveScene().name;

            foreach (var enemy in enemies)
            {
                var enemyStats = enemy.GetComponent<EnemyStats>();
                saveData.Add(new SaveData()
                {
                    EnemyID = enemyStats.enemyID,
                    Scene = activeScene,
                    EnemyStatsData = enemyStats,
                    Transform = new SerializeableTransform(enemy.transform)
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
                if (!saveData.Scene.Equals(activeScene)) continue;
                
                var enemy = Object.Instantiate(
                    enemyDataBase.GetEnemy(saveData.EnemyID), 
                    saveData.Transform.GetPosition(),
                    saveData.Transform.GetRotation());
                
                enemy.GetComponent<EnemyStats>().ApplySerializedData(saveData.EnemyStatsData);
            }
        }

        private struct SaveData
        {
            public string EnemyID;
            public string Scene;
            public object EnemyStatsData;
            public SerializeableTransform Transform;
        }
    }
}