using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBKitty_Behaviour : Projectile_Behaviour
{
    void Start()
    {
        attackDamage = kitty.GetComponent<BlackKitty_Behaviour>().getAttackdamage();
    }
    protected void OnTriggerExit2D(Collider2D other) 
    {
        checkCollision(other);
    }
    protected override void checkCollision(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(wall)) 
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EnemyUnit")
        {
            other.gameObject.GetComponent<NPC_Enemy_Behaviour>().updateHealth(-attackDamage);
        }
    }
}