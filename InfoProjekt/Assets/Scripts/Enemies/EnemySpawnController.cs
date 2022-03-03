using UnityEngine;

namespace Enemies
{
    public class EnemySpawnController : MonoBehaviour
    {

        [SerializeField] private GameObject enemy;
        [SerializeField] private int numberOfEnemies;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private LayerMask nonHostile;
        private BoxCollider2D spawnArea;
        private GameObject[] enemyInstances;

        void Start()
        {
            enemyInstances = new GameObject[numberOfEnemies];
            for (int i = 0; i < enemyInstances.Length; i++)
            {
                Transform spawnPoint = spawnPoints[(int)(Random.value * spawnPoints.Length)];
                enemyInstances[i] = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            }
            spawnArea = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            for (int i = 0; i < enemyInstances.Length; i++)
            {
                if (enemyInstances[i] == null)
                {
                    if (!spawnArea.IsTouchingLayers(nonHostile))
                    {
                        Transform spawnPoint = spawnPoints[(int)(Random.value * spawnPoints.Length)];
                        enemyInstances[i] = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
                    }
                }
            }
        }
    }
}
