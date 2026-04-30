using UnityEngine;

public class NewEmptyCSharpScript
{
 [SerializeField] private float damage;
}
private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.tag == "Player")
collision.GetComponent<Health>().TakeDamage(damage);
}