using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKitty_Behaviour : NPC_Friendly_Behaviour
{
    [SerializeField] protected float firerate;
    [SerializeField] protected float force;
    [SerializeField] protected GameObject projectile;
    protected override void initialize()
    {
        currentHealth = maxHealth;
        targetTag = "BlackTeleport";
        teleportTag = "BlackCat";
        animDirection = 3;
        isInPlace = false;
        isFed = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        initialize();
    }
    void Update()
    {
        attack();
    }
    private void FixedUpdate() 
    {
        targetGameObject = GameObject.FindWithTag(targetTag);
        targetTransform = GameObject.FindWithTag(targetTag).transform;
        if (isFed && !isInPlace)
        {
            setDirection();
            moveCharacter();
        }
        else if (isFed && isInPlace)
        {
            targetTag = "EnemyUnit";
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        collidingGameObject = other.gameObject;
        if (isFed)
        {
            teleportTheCat();
        }
    }
    protected override void attack()
    {
        if (isInPlace)
        {
            attackDir = targetTransform.position - transform.position;
            if (targetGameObject != null)
            {
                if (Time.time > nextTimeToShoot)
                {
                    nextTimeToShoot = Time.time + 1/firerate;
                    projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
                    projectileInstance.GetComponent<Rigidbody2D>().AddForce(attackDir * force);
                }
            }
        }
    }     
}
