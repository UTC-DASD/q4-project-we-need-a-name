using UnityEngine;
using UnityEngine.InputSystem;
public class Playercontrols : MonoBehaviour

{
    public PlayerInput playerInputActions;
    

    Rigidbody2D rb;
    [SerializeField] private float playerSpeed;
    private Vector2 moveInput;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

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
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
}
}
}

