using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : Unit_Behaviour
{
    private int orangeCount, plumCount, pearCount;
    protected override void initialize()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start() 
    {
        initialize();
    }
    private void Update()
    {
        setDirection();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        pickUpFruit(other);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        giveFruit(other);
    }
    protected override void setDirection()
    {
        dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            anim.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            anim.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            anim.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            anim.SetInteger("Direction", 0);
        }
        dir.Normalize();
        anim.SetBool("IsMoving", dir.magnitude > 0);
        rb.velocity = speed * dir;
    }
    private void pickUpFruit(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Orange":
            {
                orangeCount++;
                Destroy(other.gameObject);
                break;
            }
            case "Plum":
            {
                plumCount++;
                Destroy(other.gameObject);
                break;
            }
            case "Pear":
            {
                pearCount++;
                Destroy(other.gameObject);
                break;
            }
        }
    }
    private void giveFruit(Collision2D other)
    {
        switch(other.gameObject.tag) 
        {
            case "GingerCat":
            {
                if (orangeCount > 0)
                {
                    orangeCount--;
                    other.gameObject.GetComponent<NPC_Friendly_Behaviour>().feedTheCat();
                }
                break;
            }
            case "BlackCat":
            {
                if (plumCount > 0)
                {
                    plumCount--;
                    other.gameObject.GetComponent<NPC_Friendly_Behaviour>().feedTheCat();
                }
                break;
            }
            case "WhiteCat":
            {
                if (pearCount > 0)
                {
                    pearCount--;
                    other.gameObject.GetComponent<NPC_Friendly_Behaviour>().feedTheCat();
                }
                break;
            }
        }
    }
}