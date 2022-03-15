using System;
using IO;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        public static PlayerMovementController Instance;
        
        [SerializeField] private Animator animator;
        [SerializeField] private InputChannelSO inputChannel;

        [Header("Movement Variables")]
        [SerializeField] private float speed = 10;
        private float horizontalDirection;
        private bool facingRight => Math.Abs(Mathf.Sign(transform.localScale.x) - 1) < 0.01f; // basically sign(x) == 1

        [Header("Jump Variables")]
        [SerializeField] private float jumpForce = 20;
        [SerializeField] private int maxJumpInputBuffer = 4;
        private int jumpInputBuffer;

        [Header("Ground Variables")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float checkRadius = 0.25f;
        [SerializeField] private int maxGroundedBuffer = 4;
        [SerializeField] private LayerMask groundLayer;
        private bool isGrounded;
        private int groundedBuffer;
    
        private Rigidbody2D rb;
        
        private static readonly int Speed = Animator.StringToHash("speed");
        private static readonly int Grounded = Animator.StringToHash("grounded");
        private static readonly int AnimatorJump = Animator.StringToHash("jump");

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            inputChannel.JumpButtonPressed += OnJumpButtonPressed;
        }

        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
            if (isGrounded)
            {
                groundedBuffer = maxGroundedBuffer;
            }
            groundedBuffer--;
            jumpInputBuffer--;

            Move();

            if (facingRight == false && horizontalDirection < 0)
            {
                Flip();
            }
            else if(facingRight && horizontalDirection > 0)
            {
                Flip();
            }

            animator.SetFloat(Speed, Mathf.Abs(rb.velocity.x));
            animator.SetBool(Grounded, isGrounded);
        }

        private void OnJumpButtonPressed()
        {
            // ich glaub hier gibts nen buq wo doppelt force applyed wird
            // weil man als erstes grounded is und danach aber noch grounded buffer hat oder so
            if (isGrounded || groundedBuffer > 0) 
            {
                Jump();
            }
            else
            {
                jumpInputBuffer = maxJumpInputBuffer;
            }
        }
        
        void Update()
        {
            horizontalDirection = inputChannel.horizontalDirection;
            if (isGrounded && jumpInputBuffer > 0)
            {
                Jump();
                jumpInputBuffer = 0;
            }
        }

        private void Move()
        {
            rb.velocity = new Vector2(horizontalDirection * speed, rb.velocity.y);
        }

        private void Jump()
        {
            rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            animator.SetTrigger(AnimatorJump);
        }

        private void Flip()
        {
            var transformers = transform;
            Vector3 scale = transformers.localScale;
            scale.x *= -1;
            transformers.localScale = scale;
        }

        public void SetIdle()
        {
            animator.SetFloat(Speed, 0);
            animator.SetBool(Grounded, true);
        }
    }
}
