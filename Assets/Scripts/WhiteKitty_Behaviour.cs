using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKitty_Behaviour : NPC_Friendly_Behaviour
{
    [SerializeField] protected float attackSpeed;
    
    protected override void initialize()
    {
        currentHealth = maxHealth;
        targetTag = "WhiteTeleport";
        teleportTag = "WhiteCat";
        animDirection = 0;
        isInPlace = false;
        isFed = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        initialize();
    }
    private void FixedUpdate() 
    {
        if (isFed && !isInPlace)
        {
            targetTransform = GameObject.FindWithTag(targetTag).transform;
            setDirection();
            moveCharacter();
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
    private void OnCollisionStay2D(Collision2D other)
    {
        collidingGameObject = other.gameObject;
        attack();
    }
    protected override void attack()
    {
        if (collidingGameObject.tag == "EnemyUnit")
        {
            if (attackSpeed <= canAttack)
            {
                collidingGameObject.GetComponent<NPC_Enemy_Behaviour>().updateHealth(-attackDamage);
                canAttack = 0f;
            } 
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}
