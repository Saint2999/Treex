using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC_Friendly_Behaviour : NPC_Behaviour
{
    [SerializeField] protected float firerate;
    [SerializeField] protected float force;
    [SerializeField] protected GameObject projectile;
    protected GameObject targetGameObject;
    protected GameObject projectileInstance;
    protected Vector2 attackDir;
    protected string teleportTag;
    protected float nextTimeToShoot;
    protected int animDirection;
    protected bool isFed, isInPlace;

    protected abstract override void initialize();
    protected abstract override void attack();
    protected void teleportTheCat()
    {
        if (collidingGameObject.tag == targetTag)
        {
            targetGameObject = GameObject.FindWithTag(teleportTag); 
            transform.position = (Vector2)targetGameObject.transform.position + new Vector2(0, 0.7f);
            targetGameObject.tag = "Disabled";
            isInPlace = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            anim.SetInteger("Direction", animDirection);
        }
    }
    public void feedTheCat()
    {
        isFed = true;
    }
}
