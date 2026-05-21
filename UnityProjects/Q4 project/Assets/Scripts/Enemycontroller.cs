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
     public SpriteRenderer enemySpriteRenderer;
    public float speed = 2f;
    public float jumpForce = 5f;
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
            enemySpriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            enemySpriteRenderer.flipX = false;
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


