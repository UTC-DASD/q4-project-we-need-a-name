using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Enemycontroller : MonoBehaviour
{
    
    public Transform player;
    [SerializeField] private bool isGrounded;
     public SpriteRenderer EnemySpriteRenderer;
    public float speed = 2f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius = 0.2f;

    Rigidbody2D rb;
    private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);  
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
    }
     public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if(moveInput.x < 0 )
        {
            EnemySpriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            EnemySpriteRenderer.flipX = false;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) 
        {
             // Add a ground check here for better feel
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        
    }
 private void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;   
        }

        if (collision.gameObject.CompareTag("Walljump"))
        {
            Destroy(gameObject);
        }

}
}


