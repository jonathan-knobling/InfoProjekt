using Actors.Enemies;
using Actors.Player.Stats;
using UnityEngine;

namespace Actors
{
    public class Projectile: MonoBehaviour
    {
        [SerializeField] private float damage = 6.5f;

        private void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(gameObject);

            CheckForEnemyCollision(col);
            CheckForPlayerCollision(col);
        }

        private void CheckForPlayerCollision(Collider2D col)
        {
            var playerStats = col.GetComponent<PlayerStats>();
            if (playerStats is null) return;
            Debug.Log("deal damage");
            playerStats.DealDamage(damage);
        }

        private void CheckForEnemyCollision(Collider2D col)
        {
            var enemyStats = col.GetComponent<EnemyStats>();
            if (enemyStats is null) return;
            Debug.Log("deal damage");
            enemyStats.DealDamage(damage);
        }
    }
}