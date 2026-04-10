using UnityEngine;
public class Playercontrols : MonoBehaviour

{
    PlayerInputActions playerInputActions;
    

    Rigidbody2D rb;
    private float playerSpeed = 5f;
    private Vector2 moveInput;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

   

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveInput=playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * playerSpeed, rb.linearVelocity.y);
    }

}

internal class PlayerInputActions
{
}