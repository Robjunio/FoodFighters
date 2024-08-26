using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<LifeController>()!= null)
        {
            collision.GetComponent<LifeController>().GetDamage(damage);
        }
        Debug.Log(collision.gameObject);
    }
}

