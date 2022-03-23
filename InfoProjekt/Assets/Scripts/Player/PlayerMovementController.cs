using System;
using IO;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Stats.Stats))]
    public class PlayerMovementController : MonoBehaviour
    {
        public static PlayerMovementController Instance;
        
        [SerializeField] private Animator animator;
        [SerializeField] private InputChannelSO inputChannel;

        [Header("Movement Variables")] 
        [SerializeField] private float accelerationForce = 10f;
        [SerializeField] private float linearDrag = 1f;
        private float MaxSpeed => stats.Speed;
        private float horizontalDirection;
        private bool changingDirection =>(rb.velocity.x > 0f && horizontalDirection < 0f) || (rb.velocity.x < 0f && horizontalDirection > 0f);
        private bool FacingRight => Math.Abs(Mathf.Sign(transform.localScale.x) - 1) < 0.01f; // basically sign(x) == 1

        [Header("Jump Variables")]
        [SerializeField] private int maxJumpInputBuffer = 4;
        private float JumpForce => stats.JumpForce;
        private int jumpInputBuffer;

        [Header("Ground Variables")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float checkRadius = 0.25f;
        [SerializeField] private int maxGroundedBuffer = 4;
        [SerializeField] private LayerMask groundLayer;
        private bool isGrounded;
        private int groundedBuffer;

        private Rigidbody2D rb;
        private Stats.Stats stats;

        //Cached Properties
        private static readonly int CPSpeed = Animator.StringToHash("speed");
        private static readonly int CPGrounded = Animator.StringToHash("grounded");
        private static readonly int CPJump = Animator.StringToHash("jump");

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            stats = GetComponent<Stats.Stats>();
            inputChannel.JumpButtonPressed += OnJumpButtonPressed;
        }

        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
            if (isGrounded)
            {
                groundedBuffer = maxGroundedBuffer;
                ApplyLinearDrag();
            }
            groundedBuffer--;
            jumpInputBuffer--;

            Move();

            if (FacingRight == false && horizontalDirection < 0)
            {
                Flip();
            }
            else if(FacingRight && horizontalDirection > 0)
            {
                Flip();
            }

            animator.SetFloat(CPSpeed, Mathf.Abs(rb.velocity.x));
            animator.SetBool(CPGrounded, isGrounded);
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
            //eine force adden
            rb.AddForce(new Vector2(horizontalDirection * accelerationForce, 0f));
            //wenn der player schneller is als max speed die geschwindigkeit auf maxspeed setzen
            if (math.abs(rb.velocity.x) > MaxSpeed)
            {
                rb.velocity = new Vector2(horizontalDirection * MaxSpeed, rb.velocity.y);
            }
            //wenn geschwindigkeit egal welche richtung > 0
            if (rb.velocity.magnitude > 0)
            {
                stats.XPManager.AddWalkTime(Time.deltaTime);
            }
        }

        private void Jump()
        {
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            animator.SetTrigger(CPJump);
        }

        private void ApplyLinearDrag()
        {
            if (horizontalDirection < 0.01f || changingDirection)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0;
            }
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
            animator.SetFloat(CPSpeed, 0);
            animator.SetBool(CPGrounded, true);
        }
    }
}
