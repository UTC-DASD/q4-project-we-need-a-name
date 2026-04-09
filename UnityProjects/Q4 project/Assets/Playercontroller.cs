

using UnityEngine;
using UnityEngine.InputSystem;


public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveinput;
    public Rigidbody2D rb2d;
    public float movespeed = 5;
    Vector2 movement;
     void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    public void onmove(InputValue value)
    {
        moveinput = value.Get<Vector2>();
    }

    
    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(moveinput.x * movespeed, moveinput.y *movespeed);
    }
  
    }
  
