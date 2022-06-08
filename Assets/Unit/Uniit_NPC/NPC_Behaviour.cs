using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Behaviour : Unit_Behaviour
{
    [SerializeField] protected float attackDamage;
    [SerializeField] public float attackSpeed;
    public float canAttack;
    [SerializeField] protected float checkRadius;
    [SerializeField] protected float attackRadius;
    public bool shouldRotate;
    [SerializeField] protected LayerMask targetLayer;
    protected string targetTag;
    protected Transform target;
    protected bool isInChaseRange;
    protected bool isInAttackRange;

    protected void initialize()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag(targetTag).transform;
    }


    protected void setDirection()
    {
        anim.SetBool("IsRunning", isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, targetLayer);
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


    protected void moveCharacter(Vector2 dir)
    {
        if (isInChaseRange)  
        {
            rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
        }
    }
}