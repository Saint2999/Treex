using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndgame : MonoBehaviour
{
    public GameObject deathCollider; // Объект, к которому прикасается враг и игра заканчивается
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == deathCollider.tag)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
