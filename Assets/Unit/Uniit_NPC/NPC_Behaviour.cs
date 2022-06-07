using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Behaviour : Unit_Behaviour
{
    public float attackDamage;
    public float attackSpeed;
    public float canAttack;
    public float checkRadius;
    public float attackRadius;
    public bool shouldRotate;
    public LayerMask whatIsPlayer;
    protected Transform target;
    protected bool isInChaseRange;
    protected bool isInAttackRange;

    private void Start()
    {
        
    }


    private void Update()
    {
    
    }


    protected void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}