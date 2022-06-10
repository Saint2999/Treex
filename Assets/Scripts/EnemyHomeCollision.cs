using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomeCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Home")
        //if (other.gameObject.CompareTag("Finish"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
