using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Enemy_Behaviour : NPC_Behaviour
{
    private void Start()
    {
        targetTag = "FriendlyUnit";
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
