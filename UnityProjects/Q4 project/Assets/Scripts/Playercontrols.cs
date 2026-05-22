using UnityEngine.SceneManagement;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor.Tilemaps;
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
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkRadius = 0.2f;
    private bool isWallSliding;
    private float wallslidingspeed = 2f;
    private bool iswalljumping;
    private float walljumpingdirection;
    private float walljumpingtime = 0.2f;
    private float walljumpingcounter;
    private float walljumpingduration = 0.4f;
    private Vector2 walljumpingpower = new Vector2(8f, 16f);
    public SpriteRenderer playerSpriteRenderer;

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
    
    // Link this to your Input Action 'Move' via Unity Events or C# Events
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if(moveInput.x < 0 )
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            playerSpriteRenderer.flipX = false;
        }
    }
    private void Walljump()
    {
        if (isWallSliding)
        {
            iswalljumping = false;
            walljumpingdirection = -transform.localScale.x;
            walljumpingcounter = walljumpingtime;
        }
        else
        {
            walljumpingcounter -= Time.deltaTime;
        }
        if (playerInputActions.actions["WallJump"].triggered && (isWallSliding || walljumpingcounter > 0f))
        {
            iswalljumping = true;
            rb.linearVelocity = new Vector2(walljumpingdirection * walljumpingpower.x, walljumpingpower.y);
            walljumpingcounter = 0f;
        }
    }

    
    private void Update()
    {

        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGrounded)
        {
            jumpsRemaining = maxJumps;  // Reset jumps when isgrounded
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
            isGrounded = true;
            
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            jumpsRemaining = maxJumps;
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Walljump"))
        {
            jumpsRemaining = maxJumps;
            isGrounded = true;   
        }
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // restart the level when colliding with an enemy
        }
      
    }
}

