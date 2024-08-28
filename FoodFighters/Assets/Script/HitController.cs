using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public GameObject impactPrefab;
    public GameObject bigImpactPrefab;
    public LifeController lifeController;
    public Rigidbody2D rb;

    public void OnTriggerEnter2D(Collider2D col)
    {
        var dir = transform.position - col.transform.position;
        dir = dir.normalized;

        if (col.gameObject.CompareTag("Attack"))
        {
            lifeController.GetDamage(10);
            rb.AddForce(dir * 10, ForceMode2D.Impulse);
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
        }

        else if (col.gameObject.CompareTag("HeavyAttack"))
        {
            lifeController.GetDamage(20);
            rb.AddForce(dir * 40, ForceMode2D.Impulse);
            Instantiate(bigImpactPrefab, transform.position, Quaternion.identity);
        }
    }
}
