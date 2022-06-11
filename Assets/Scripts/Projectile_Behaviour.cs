using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Behaviour : MonoBehaviour
{
    [SerializeField] protected GameObject kitty;
    [SerializeField] protected string wall;
    protected float attackDamage;

    protected void OnTriggerExit2D(Collider2D other) 
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
