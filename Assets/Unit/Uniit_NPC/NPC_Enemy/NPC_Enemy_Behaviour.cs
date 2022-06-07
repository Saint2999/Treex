using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Enemy_Behaviour : NPC_Behaviour
{
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("FriendlyUnit").transform;
    }

    private void Update()
    {
        anim.SetBool("IsRunning", isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
    }

    private void FixedUpdate() 
    {
        if (isInChaseRange && !isInAttackRange)  
        {
            MoveCharacter(movement);
        }     
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
