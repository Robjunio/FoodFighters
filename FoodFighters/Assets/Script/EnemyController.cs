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

    private void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var currentVelocity = rb.velocity;
        rb.velocity = Vector2.Lerp(currentVelocity, Vector2.zero, velocity);
    }
}



