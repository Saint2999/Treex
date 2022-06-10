using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKitty_Behaviour : NPC_Friendly_Behaviour
{
    void Start()
    {
        initialize();
    }

    void Update()
    {
    }

    private void FixedUpdate() 
    {
        if (isFed && !isInPlace)
        {
            targetTransform = GameObject.FindWithTag(targetTag).transform;
            setDirection();
            moveCharacter(movement);
        }
    }

    protected override void initialize()
    {
        targetTag = "WhiteTeleport";
        whereToTeleport = "WhiteCat";
        direction = 0;
        isInPlace = false;
        isFed = false;
        checkRadius = 5;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isFed)
        {
            teleportTheCat(other);
        }
    }
}
