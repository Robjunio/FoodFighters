using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public LifeController lifeController;
    public Rigidbody2D rb;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Attack"))
        {
            print("Triggou ataque");
            lifeController.GetDamage(10);
            rb.AddForce(Vector2.right * 25, ForceMode2D.Impulse);
        }

        else if (col.gameObject.CompareTag("HeavyAttack"))
        {
            print("Triggou ataque Pesado");
            lifeController.GetDamage(20);
            rb.AddForce(Vector2.right * 60, ForceMode2D.Impulse);
        }
    }
}
