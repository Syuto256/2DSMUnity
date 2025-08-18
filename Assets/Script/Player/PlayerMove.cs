using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool isGrounded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

    }


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }

    }
   

    private bool IsGround()
    {
        // 地面との接触判定
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);
        return hitColliders.Length > 0;
    }
}