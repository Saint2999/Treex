using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndgame : MonoBehaviour
{
    public GameObject deathCollider; // ������, � �������� ����������� ���� � ���� �������������
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == deathCollider.tag)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
