using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovementController : MonoBehaviour
    {

        [SerializeField] private Animator animator;
        private EnemyStats stats;
        private Rigidbody2D rb;
        private bool facingRight => Mathf.Sign(transform.localScale.x) == 1;
    
        void Start()
        {
            stats = GetComponent<EnemyStats>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            animator.SetFloat("speed", math.abs(rb.velocity.x));
        }

        public void MoveRight()
        {
            rb.velocity = new Vector2(stats.GetSpeed(), rb.velocity.y);
            if (!facingRight)
            {
                Flip();
            }
        }

        public void MoveLeft()
        {
            rb.velocity = new Vector2(-stats.GetSpeed(), rb.velocity.y);
            if (facingRight)
            {
                Flip();
            }
        }

        public void StopMoving()
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        private void Flip()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
