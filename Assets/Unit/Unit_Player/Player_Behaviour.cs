using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : Unit_Behaviour
{

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
}