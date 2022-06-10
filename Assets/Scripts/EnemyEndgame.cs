using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndgame : MonoBehaviour
{
    public GameObject deathCollider; // Объект, к которому прикасается враг и игра заканчивается
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(deathCollider.tag))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
