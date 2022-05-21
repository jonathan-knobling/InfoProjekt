using UnityEngine;

namespace Tests
{
    public class TestMovementController: MonoBehaviour
    {
        private Rigidbody2D rb;

        [SerializeField] private float speed = 2f;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        }
    }
}