using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private LayerMask nonHostile;
    private BoxCollider2D spawnArea;
    private GameObject enemyInstance;

    void Start()
    {
        enemyInstance = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        spawnArea = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (enemyInstance == null)
        {
            if (!spawnArea.IsTouchingLayers(nonHostile)) 
            {
                enemyInstance = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
