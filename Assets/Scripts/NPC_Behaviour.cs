using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Behaviour : Unit_Behaviour
{
    [SerializeField] protected float attackDamage;
    [SerializeField] public float attackSpeed;
    public float canAttack;
    [SerializeField] protected float checkRadius;
    //[SerializeField] protected float attackRadius;
    [SerializeField] protected bool shouldRotate;
    protected LayerMask targetLayer;
    protected string targetTag;
    protected Transform targetTransform;
    //protected bool isInChaseRange;
    //protected bool isInAttackRange;
    //protected Vector3 savedPosition;

    protected virtual void initialize()
    {
        // anim = GetComponent<Animator>();
        // rb = GetComponent<Rigidbody2D>();
        // target = GameObject.FindWithTag(targetTag).transform;
    }


    protected void setDirection()
    {
        //anim.SetBool("IsMoving", true);
        //isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, targetLayer);
        dir = targetTransform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        anim.SetBool("IsMoving", movement.magnitude > 0);
        if (shouldRotate)
        {
            switch(dir.x)
            {
                case >0:
                {
                    anim.SetInteger("Direction", 2);
                    break;
                }

                case <0:
                {
                    anim.SetInteger("Direction", 3);
                    break;
                }
            }
            switch(dir.y)
            {
                case >0:
                {
                    anim.SetInteger("Direction", 1);
                    break;
                }

                case <0:
                {
                    anim.SetInteger("Direction", 0);
                    break;
                }
            }
        }
    }


    protected void moveCharacter(Vector2 dir)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
        //if (isInChaseRange)  
        //{
            //rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
        //}

    }
}