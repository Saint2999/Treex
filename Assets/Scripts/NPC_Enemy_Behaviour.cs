using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Enemy_Behaviour : NPC_Behaviour
{
    [SerializeField] protected float attackSpeed;
    
    protected override void initialize()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        targetTag = "Home";
        targetTransform = GameObject.FindWithTag(targetTag).transform;
    }
    private void Start()
    {
        initialize();
    }
    private void Update()
    {
        setDirection();
    }
    private void FixedUpdate() 
    {
        moveCharacter();
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        collidingGameObject = other.gameObject;
        attack();
    }
    protected override void attack()
    {
        if (collidingGameObject.tag == "WhiteCat")
        {
            if (attackSpeed <= canAttack)
            {
                collidingGameObject.GetComponent<WhiteKitty_Behaviour>().updateHealth(-attackDamage);
                canAttack = 0f;
            } 
            else
                {
                    canAttack += Time.deltaTime;
                }
        }
        if (collidingGameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                collidingGameObject.GetComponent<Player_Behaviour>().updateHealth(-attackDamage);
                canAttack = 0f;
            } 
            else
                {
                    canAttack += Time.deltaTime;
                }
        }
    }
}
