using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public Animator anim;
    public int enemyMaxLife;
    public int currentLife;
    public bool isDead;
    public float stunTime;
    private float m_stunTimer;
    public bool isStunned;


    // Start is called before the first frame update
    void Start()
    {
        currentLife = enemyMaxLife;
        isDead = false;
    }

    void FixedUpdate()
    {
        if (isStunned)
        {
            if (m_stunTimer > stunTime)
            {
                isStunned = false;
            }
            else
            {
                m_stunTimer += Time.fixedDeltaTime;
            }
        }
    }

    // Update is called once per frame
    public void GetDamage(int damage)
    {
       if(currentLife - damage <= 0)
       {
            currentLife = 0;

            isDead = true;

            anim.SetTrigger("Death");
       }
       else
       {
            m_stunTimer = 0;
            isStunned = true;
            anim.SetTrigger("GetHit");
            currentLife -= damage;
       }
    }
}
