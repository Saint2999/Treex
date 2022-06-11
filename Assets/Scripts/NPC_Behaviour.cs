using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class NPC_Behaviour : Unit_Behaviour
{
    [SerializeField] protected float attackDamage;
    protected float canAttack;
    protected LayerMask targetLayer;
    protected string targetTag;
    protected Transform targetTransform;
    protected GameObject collidingGameObject;

    protected abstract override void initialize();
    protected abstract void attack();
    protected override void setDirection()
    {
        dir = targetTransform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        anim.SetBool("IsMoving", dir.magnitude > 0);
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
    protected void moveCharacter()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
    }
    public float getAttackdamage()
    {
        return attackDamage;
    }
}