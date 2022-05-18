using System;
using UnityEngine;

namespace Actors.Enemies
{
    public class EnemyMovementController
    {
        private readonly GameObject go;
        private readonly Animator animator;
        private readonly Rigidbody2D rb;
        private readonly EnemyStats stats;

        private static readonly int Speed = Animator.StringToHash("speed"); // cached property
        private bool FacingRight => Math.Abs(Mathf.Sign(go.transform.localScale.x) - 1) < 0.01f; // basically sign(x) == 1

        public EnemyMovementController(GameObject go)
        {
            this.go = go;
            rb = go.GetComponent<Rigidbody2D>();
            //animator = go.GetComponent<Animator>();
            stats = go.GetComponent<EnemyStats>();
        }

        public void Update()
        {
            //animator.SetFloat(Speed, Math.Abs(rb.velocity.magnitude));
        }

        public void Move(Vector2 dir)
        {
            if(dir.x > 0 && !FacingRight) Flip();

            rb.velocity = dir.normalized * stats.Speed;
        }

        private void Flip()
        {
            var transform1 = go.transform;
            Vector3 scale = transform1.localScale;
            scale.x *= -1;
            transform1.localScale = scale;
        }
    }
}
