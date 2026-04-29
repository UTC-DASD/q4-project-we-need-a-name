using UnityEngine;
using UnityEngine.InputSystem;
public class Playercontrols : MonoBehaviour

{
    public PlayerInput playerInputActions;
    

    Rigidbody2D rb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private int maxJumps = 2; // e.g., 2 for a double jump
private int jumpsRemaining;
    private Vector2 moveInput;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkRadius = 0.2f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
            jumpsRemaining = maxJumps; // Initialize jumps
            // Perform the check every frame or just before the jump
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }
    
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * playerSpeed, rb.linearVelocity.y);
    }

    public void HorizontalMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();  
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpsRemaining > 0) 
        {
             // Add a ground check here for better feel
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            jumpsRemaining--;
        }
        
    }
    private void Update()
    {
        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded)
        {
            jumpsRemaining = maxJumps; // Reset jumps when isgrounded
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
            isGrounded = true;
        }
    }
}

