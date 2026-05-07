using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SpikeTrapController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float bounceForce = 10f; // Force to push the player up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset player Y velocity and bounce them up
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset Y
                rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
           
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    } 
}
