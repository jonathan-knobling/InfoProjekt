using System;
using System.Collections.Generic;
using Tech.IO.Saves;
using UnityEngine;
using Util.Serialization;
using Random = UnityEngine.Random;

namespace Environment.Actors.Enemies.Spawning
{
    public class EnemySpawnController : MonoBehaviour, ISaveable
    {

        [SerializeField] private GameObject enemy;
        [SerializeField] private int numberOfEnemies;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private LayerMask nonHostile;
        private BoxCollider2D spawnArea;
        private List<GameObject> enemyInstances;

        void Start()
        {
            enemyInstances = new List<GameObject>();
            for (int i = 0; i < enemyInstances.Count; i++)
            {
                Transform spawnPoint = spawnPoints[(int)(Random.value * spawnPoints.Length)];
                enemyInstances[i] = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            }
            spawnArea = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            while (enemyInstances.Count < numberOfEnemies)
            {
                if (!spawnArea.IsTouchingLayers(nonHostile))
                {
                    Transform spawnPoint = spawnPoints[(int)(Random.value * spawnPoints.Length)];
                    //instantiate new enemy and add to instances list
                    enemyInstances.Add(Instantiate(enemy, spawnPoint.position, spawnPoint.rotation));
                }
            }
        }
        
        
        //Saving
        public object SerializeComponent()
        {
            //neue save data erstellen mit und den array von enemy data initialisieren auf die länge des enemyInstances array
            SaveData data = new SaveData
            {
                enemies = new EnemyData[enemyInstances.Count]
            };

            //durch den array loopen und data eintragen
            for (int i = 0; i < enemyInstances.Count; i++)
            {
                if(!enemyInstances[i].Equals(null))
                {
                    data.enemies[i] = new EnemyData()
                    {
                        EnemySerializedData = enemyInstances[i].GetComponent<EnemyStats>().SerializeComponent(),
                        enemyTransform = new SerializeableTransform(enemyInstances[i].transform)
                    };
                }
            }

            return data;
        }
        
        public void ApplySerializedData(object serializedData)
        {
            var data = (SaveData) serializedData;

            enemyInstances.Clear();
            
            foreach (var enemyData in data.enemies)
            {
                //instantiate prefab at stored position and rotation
                var instantiatedObject = Instantiate(enemy, enemyData.enemyTransform.GetPosition(), 
                                                            enemyData.enemyTransform.GetRotation());

                //apply the serialized data
                instantiatedObject.GetComponent<EnemyStats>().ApplySerializedData(enemyData.EnemySerializedData);
                
                enemyInstances.Add(instantiatedObject);
            }
        }

        [Serializable]
        private struct SaveData
        {
            public EnemyData[] enemies;
        }

        [Serializable]
        private struct EnemyData
        {
            public object EnemySerializedData;
            public SerializeableTransform enemyTransform;
        }
    }
}
