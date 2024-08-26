using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float velocity;
    public float attackDistance;
    public float attackDelayTimer;
    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 movementDirection;
    private GameObject player;
    private bool canAttack = true;
    private float currentAttackDelayTime;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentAttackDelayTime = attackDelayTimer;

    }

    // Update is called once per frame
    void Update()
    {
        currentAttackDelayTime -= Time.deltaTime;

        if (currentAttackDelayTime <= 0)
        {
            canAttack = true;
            currentAttackDelayTime = attackDelayTimer;
        }

        //Calcular a Direção dele em relação ao jogador;
        movementDirection = (player.transform.position - gameObject.transform.position);
        
        if (movementDirection.magnitude > attackDistance)
        {
            rb.velocity = movementDirection.normalized * velocity;
            animator.SetTrigger("walk");
        }
        else
        {
            if (canAttack == true)
            {
                animator.SetTrigger("punch");
                canAttack = false;
                rb.velocity = Vector2.zero;
            }
            else
            {
                animator.SetTrigger("idle");
                rb.velocity = Vector2.zero;
            }
         
       
        }


        if (movementDirection.normalized.x >= 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
           
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
}



