using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetHealth();

      spriteRender = GetComponent<spriteRender>();
      GameController.OnReset += ResetHealth;
      HealthItem.OnHealthCollect += Heal;

    }

    // Update is called once per frame
    void Update()
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            TakeDamage (enemy.damage);
        }
        Trap trap = collision.GetComponent<Trap>();
        if (trap && trap.damage > 0)
        {
            TakeDamage(trap.damage);
        }
    }
}
