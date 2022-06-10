using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : Unit_Behaviour
{

    private int orangeCount, plumCount, pearCount;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
            anim.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
            anim.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
            anim.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
            anim.SetInteger("Direction", 0);
        }
        movement.Normalize();
        anim.SetBool("IsMoving", movement.magnitude > 0);
        rb.velocity = speed * movement;
    }
    private void OnTriggerEnter2D(Collider2D other)
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
    private void OnCollisionEnter2D(Collision2D other)
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