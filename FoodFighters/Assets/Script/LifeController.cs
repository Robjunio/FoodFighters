using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{

public int enemyMaxLife;
public int currentLife;
public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = enemyMaxLife;
        isDead = false;
        
    }

    // Update is called once per frame
   public void GetDamage(int damage)
    {
       if(currentLife - damage <= 0)
       {
           isDead = true;
           Destroy(gameObject);
       }
       else
       {
           currentLife = damage;
       }
    }
}
