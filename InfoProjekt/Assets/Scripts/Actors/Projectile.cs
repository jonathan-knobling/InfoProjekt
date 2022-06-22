using Actors.Enemies;
using UnityEngine;

namespace Actors
{
    public class Projectile: MonoBehaviour
    {
        [SerializeField] private float damage = 6.5f;

        private void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(gameObject);

            var enemyStats = col.GetComponent<EnemyStats>();
            if (enemyStats is null) return;
            Debug.Log("deal damage");
            enemyStats.DealDamage(damage);
        }
    }
}