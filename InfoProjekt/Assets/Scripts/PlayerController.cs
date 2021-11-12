using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float speed = 8;
    private float horizontalDirection;
    private bool facingRight = true;

    [Header("Jump Variables")]
    [SerializeField] private float jumpForce = 25;
    [SerializeField] private int maxJumpInputBuffer = 4;
    private int jumpInputBuffer = 0;

    [Header("Ground Variables")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.25f;
    [SerializeField] private int maxGroundedBuffer = 4;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private int groundedBuffer = 0;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        else if(facingRight == true && horizontalDirection > 0)
        {
            Flip();
        }
    }

    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && (isGrounded || groundedBuffer > 0)) // ich glaub hier gibts nen buq wo doppelt force applyed wird weil man als erstes grounded is und danach aber noch grounded buffer hat oder so
        {
            Jump();
        }
        else if (Input.GetButtonDown("Jump"))
        {
            jumpInputBuffer = maxJumpInputBuffer;
        }
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
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
