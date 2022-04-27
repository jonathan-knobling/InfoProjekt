using Actors.Player.Stats;
using Tech;
using Unity.Mathematics;
using UnityEngine;

namespace Actors.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private EventChannelSO eventChannel;
        private Animator animator;
        private PlayerStats stats;
        private Rigidbody2D rb;

        [Header("Movement Variables")]
        [SerializeField] private float accelerationForce = 65;
        [SerializeField] private float linearDrag = 10f;
        private float MaxSpeed => stats.Speed;
        private Vector2 direction;
        private bool ChangingDirection =>    rb.velocity.x > 0.1f && direction.x < 0.1f
                                          || rb.velocity.x < 0.1f && direction.x > 0.1f 
                                          || rb.velocity.y > 0.1f && direction.y < 0.1f
                                          || rb.velocity.y < 0.1f && direction.y > 0.1f;

        private bool FacingRight => math.abs(math.sign(transform.localScale.x) - 1) > 0.001f; // basically sign(x) == 1
        
        //Cached Properties
        private static readonly int CPSpeed = Animator.StringToHash("speed");
        private static readonly int CPDirX = Animator.StringToHash("dir_x");
        private static readonly int CPDirY = Animator.StringToHash("dir_y");
        private static readonly int CPLastDirX = Animator.StringToHash("last_dir_x");
        private static readonly int CPLastDirY = Animator.StringToHash("last_dir_y");

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            stats = GetComponent<PlayerStats>();
            animator = GetComponent<Animator>();

            eventChannel.PlayerChannel.AddPlayerMovementController(this);
            eventChannel.PlayerChannel.OnSetIdle += SetIdle;
        }

        private void Update()
        {
            direction = eventChannel.InputChannel.InputDirection;
            eventChannel.PlayerChannel.Velocity = rb.velocity.magnitude;
        }

        private void FixedUpdate()
        {
            ApplyLinearDrag();
            Move();
            
            //set animator values
            animator.SetFloat(CPSpeed, math.abs(rb.velocity.magnitude));
            animator.SetFloat(CPDirX, math.sign(rb.velocity.x));
            animator.SetFloat(CPDirY, math.sign(rb.velocity.y));
            if (math.sign(rb.velocity.x) != 0)
            {
                animator.SetFloat(CPLastDirX, math.sign(rb.velocity.x));
            }
            if (math.sign(rb.velocity.y) != 0)
            {
                animator.SetFloat(CPLastDirY, math.sign(rb.velocity.y));
            }

            if (!FacingRight && direction.x < 0)
            {
                Flip();
            }
            else if (FacingRight && direction.x > 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            var tf = transform;
            Vector3 scale = tf.localScale;
            scale.x *= -1;
            tf.localScale = scale;
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
            animator.SetFloat(CPSpeed, 0);
            animator.SetFloat(CPDirX, 0);
            animator.SetFloat(CPDirY, 0);
        }
    }
}
