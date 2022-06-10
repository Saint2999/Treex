using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndgame : MonoBehaviour
{
    public GameObject deathCollider; // ������, � �������� ����������� ���� � ���� �������������
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(deathCollider.tag))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
