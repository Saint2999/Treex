using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Enemy_Behaviour : NPC_Behaviour
{
    private void Start()
    {
        checkRadius = 100;
        targetLayer = 8;
        targetTag = "Home";
        initialize();
    }

    private void Update()
    {
        setDirection();
    }

    private void FixedUpdate() 
    {
        moveCharacter(movement);
    }

    protected override void initialize()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        targetTransform = GameObject.FindWithTag(targetTag).transform;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "FriendlyUnit")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<NPC_Friendly_Behaviour>().updateHealth(-attackDamage);
                canAttack = 0f;
            } 
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}
