using Actors.Player.Stats;
using Tech.IO.PlayerInput;
using UnityEngine;

namespace Actors.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerStats))]
    //[RequireComponent(typeof(Animator))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementChannelSO movementChannel;
        [SerializeField] private InputChannelSO inputChannel;
        private Animator animator;
        private PlayerStats stats;
        private Rigidbody2D rb;

        [Header("Movement Variables")]
        [SerializeField] private float accelerationForce = 65;
        [SerializeField] private float linearDrag = 10f;
        private float MaxSpeed => stats.Speed;
        private Vector2 direction;
        private bool ChangingDirection =>    rb.velocity.x > 0.001f && direction.x < 0.001f
                                          || rb.velocity.x < 0.001f && direction.x > 0.001f 
                                          || rb.velocity.y > 0.001f && direction.y < 0.001f
                                          || rb.velocity.y < 0.001f && direction.y > 0.001f;
        
        //Cached Properties
        private static readonly int CPSpeed = Animator.StringToHash("speed");

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            stats = GetComponent<PlayerStats>();
            animator = GetComponent<Animator>();
            
            movementChannel.AddPlayerMovementController(this);
            movementChannel.OnSetIdle += SetIdle;
        }

        private void Update()
        {
            direction = inputChannel.InputDirection;
        }

        private void FixedUpdate()
        {
            ApplyLinearDrag();
            Move();
            
            //animator.SetFloat(CPSpeed, Mathf.Abs(rb.velocity.x));
        }
        
        private void Move()
        {
            rb.AddForce(direction.normalized * accelerationForce);
            
            if (rb.velocity.magnitude > MaxSpeed)
            {
                rb.velocity = direction.normalized * MaxSpeed;
            }
            
            if (rb.velocity.magnitude > 0.001f)
            {
                stats.XPManager.AddWalkTime(Time.deltaTime);
            }
        }
        
        private void ApplyLinearDrag()
        {
            if (direction.magnitude < 0.001f || ChangingDirection)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0;
            }
        }
        
        private void SetIdle()
        {
            //animator.SetFloat(CPSpeed, 0);
        }
    }
}
