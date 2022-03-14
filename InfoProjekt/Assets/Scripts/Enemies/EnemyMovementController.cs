using System;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    public class EnemyMovementController : MonoBehaviour
    {

        [SerializeField] private Animator animator;
        private EnemyStats stats;
        private Rigidbody2D rb;
        private static readonly int Speed = Animator.StringToHash("speed"); // cached property
        private bool facingRight => Math.Abs(Mathf.Sign(transform.localScale.x) - 1) < 0.01f; // basically sign(x) == 1
    
        void Start()
        {
            stats = GetComponent<EnemyStats>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            animator.SetFloat(Speed, math.abs(rb.velocity.x));
        }

        public void MoveRight(float speed)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (!facingRight)
            {
                Flip();
            }
        }

        public void MoveLeft(float speed)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
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
            var transform1 = transform;
            Vector3 scale = transform1.localScale;
            scale.x *= -1;
            transform1.localScale = scale;
        }
    }
}
