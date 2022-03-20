using System;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovementController : MonoBehaviour
    {

        [SerializeField] private Animator animator;
        private Rigidbody2D rb;
        private float currentVelocityX;
        
        private static readonly int Speed = Animator.StringToHash("speed"); // cached property
        private bool FacingRight => Math.Abs(Mathf.Sign(transform.localScale.x) - 1) < 0.01f; // basically sign(x) == 1
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            animator.SetFloat(Speed, math.abs(rb.velocity.x));
            rb.velocity = new Vector2(currentVelocityX, rb.velocity.y);
        }

        [Description("Automatically determines direction (- sign is left and + sign is right)")]
        public void Move(float speed)
        {
            //wenn sign(direction) == 1 ; also direction == right
            if (Math.Abs(Mathf.Sign(speed) - 1) < 0.01f)
            {
                MoveRight(speed);
            }
            else if (speed != 0)
            {
                MoveLeft(speed);
            }
            else
            {
                StopMoving();
            }
        }
        
        public void MoveRight(float speed)
        {
            Debug.Log("Move Right");
            //abs damit es auch auf jeden fall sich nach rechts bewegt
            currentVelocityX = Math.Abs(speed);
            if (!FacingRight)
            {
                Flip();
            }
        }

        public void MoveLeft(float speed)
        {
            Debug.Log("Move Left"); 
            //abs damit es auch auf jeden fall sich nach links bewegt
            currentVelocityX = -Mathf.Abs(speed);
            if (FacingRight)
            {
                Flip();
            }
        }

        public void StopMoving()
        {
            Debug.Log("Stop Moving");
            currentVelocityX = 0;
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
