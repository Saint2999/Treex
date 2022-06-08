using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Friendly_Behaviour : NPC_Behaviour
{
    private Collider2D previousCollider;
    private void Start()
    {
        targetTag = "EnemyUnit";
        initialize();
    }

    void Update()
    {
        setDirection();
    }

    private void FixedUpdate() 
    {
        moveCharacter(movement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == targetLayer)
        {
            other.gameObject.layer = 0;
            if (previousCollider != null)
            {
                previousCollider.gameObject.layer = targetLayer;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == targetLayer)
        {
            previousCollider = other;
        }
    }

}
