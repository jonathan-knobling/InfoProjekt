using UnityEngine;

namespace Actors.Enemies
{
    public class DemoEnemyController : MonoBehaviour
    {
        [SerializeField] private float fovRadius = 5f;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float shootingSpeed = 1.2f;

        private GameObject target;
        private float timer;

        private void Start()
        {
            timer = shootingSpeed;
            target = GameObject.Find("Player");
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer > 0) return;

            timer = shootingSpeed;

            var position = transform.position;
            var projectileDirection = (target.transform.position - position).normalized;
            var projectile = Instantiate(projectilePrefab, position + projectileDirection * 2f, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = projectileDirection * 7f;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, fovRadius);
        }
    }
}