using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Friendly_Behaviour : NPC_Behaviour
{
    protected bool isFed, isInPlace;
    protected GameObject targetGameObject;
    protected string whereToTeleport;
    protected int direction;
    public void feedTheCat()
    {
        isFed = true;
    }
    
    protected void teleportTheCat(Collider2D other)
    {
        if (other.gameObject.tag == targetTag)
        {
            targetGameObject = GameObject.FindWithTag(whereToTeleport); 
            transform.position = (Vector2)targetGameObject.transform.position + new Vector2(0, 0.7f);
            targetGameObject.tag = "Disabled";
            isInPlace = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            anim.SetInteger("Direction", direction);
        }
    }
}
