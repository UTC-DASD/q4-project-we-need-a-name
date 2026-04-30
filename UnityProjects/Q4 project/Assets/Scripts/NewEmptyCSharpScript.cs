using UnityEngine;

public class NewEmptyCSharpScript
{
    [Header("Firetrap Timers")]
[SerializeField] private float activationDelay;
[SerializeField] private float activeTime;
private Animator anim;
private SpriteRenderer spriteRend;

private bool triggered; //when the trap gets triggered
private bool active; //when the trap is acctive and can hurt the player

private void Awake()
{
anim = GetComponent<Animator>();
spriteRend = GetComponent<SpriteRenderer>();
}

private void OnTriggerEnter2D(Collider2D collision)
{
if(collision.tag == "Player")
}
if (!triggered)
{
}
}