using System.Collections.Generic;
using UnityEngine;

namespace Environment.Spawning
{
    public class EnemySpawnPoint : MonoBehaviour
    {

        [SerializeField] private GameObject enemySpawnPrefab;
        [SerializeField] private int numberOfEnemies;
        [SerializeField] private Transform spawnPoint;
        private List<GameObject> enemyInstances;

        void Start()
        {
            enemyInstances = new List<GameObject>();
        }

        void Update()
        {
            while (enemyInstances.Count < numberOfEnemies)
            {
                enemyInstances.Add(Instantiate(enemySpawnPrefab, spawnPoint.position, spawnPoint.rotation));
            }
        }
    }
}
