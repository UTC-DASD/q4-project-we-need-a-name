using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle Detected");
            enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
          
            }
        }
    }

