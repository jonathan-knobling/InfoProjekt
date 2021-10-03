using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Layer Masks")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Movement Variables")]
    [SerializeField] float movementAcceleration;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float groundLinearDrag;
    private float horizontalDirection;
    private bool facingRight = true;
    private bool changingDirection => (rb.velocity.x > 0f && horizontalDirection < 0f) ||
                                      (rb.velocity.x < 0f && horizontalDirection > 0f);

    [Header("Jump Variables")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float airLinearDrag;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpFallMultiplier;
    private int jumpInputBuffer = 0;

    [Header("Ground Collision Variables")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    private bool isGrounded;
    private int groundedBuffer = 0;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer); // schaut ob ein circle mit dem Radius checkRadius, an der Position vom Objekt GroundCheck mit Objekten collided vom layer ground
        if (isGrounded)
        {
            groundedBuffer = 5; // 5 fixedupdates nachdem man nich mehr grounded is kann man trotzdem noch springen falls man knapp zu sp�t jump dr�ckt
        }
        groundedBuffer--;
        jumpInputBuffer--;

        MoveCharacter();

        if (isGrounded)
        {
            ApplyGroundLinearDrag();
        }
        else
        {
            ApplyAirLinearDrag();
            FallMultiplier();
        }

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
        horizontalDirection = Input.GetAxisRaw("Horizontal"); // returned -1 f�r links und 1 f�r rechts 0 f�r weder noch
        if (Input.GetButtonDown("Jump") && (isGrounded || groundedBuffer > 0))// im normalen update weil fixedUpdate nich jeden frame l�uft und deswegen manchmal der input nich detected wird
        {
            Jump();
        }
        else if (Input.GetButtonDown("Jump")) // wenn man in der luft jump dr�ckt wird das f�r 7 fixed updates gespeichert falls man kurz davor is den boden zu ber�hren
        {
            jumpInputBuffer = 7;
        }
        if (isGrounded && jumpInputBuffer > 0) // wenn man den boden ber�hrt und kurz davor jump gedr�ckt hat
        {
            Jump();
        }
    }

    private void MoveCharacter()
    {
        rb.AddForce(new Vector2(horizontalDirection, 0f) * movementAcceleration); // beschleunigungs force hinzuf�gen

        if (Math.Abs(rb.velocity.x) > maxMoveSpeed) // wenn absoluter(plus also egal in welche richtung) x-geschwindigkeits wert gr�sser ist als maxMoveSpeed
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMoveSpeed, rb.velocity.y); // x velocity auf maxMoveSpeed setzen aber in die richtige richtung(Sign) y bleibt gleich
        }
    }

    private void ApplyGroundLinearDrag()
    {
        if (Math.Abs(horizontalDirection) == 0 || changingDirection) // bei keinem input oder bei richtungswechsel
        {
            rb.drag = groundLinearDrag; // linear drag zum rigidbody applyen damit der boden sich nich wie eis anf�hlt
        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void ApplyAirLinearDrag()
    {
        rb.drag = airLinearDrag;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); // y geschwindigkeit auf 0 setzen
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // jumpforce richtung +y hinzuf�gen
    }

    private void FallMultiplier()
    {
        if (rb.velocity.y < 0) // wenn die y geschwindigkeit negativ is also nach unten gravity auf fallmultiplier setzen
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // wenn man jump losl�sst mehr gravity damit man nich so hoch springt
        {
            rb.gravityScale = lowJumpFallMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
