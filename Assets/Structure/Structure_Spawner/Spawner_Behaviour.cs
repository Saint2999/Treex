using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Behaviour : MonoBehaviour
{
    [SerializeField] private float spawnRadius;
    [SerializeField] private float time;
    private Vector2 spawnPos;
    public GameObject unit; 
    public int numberOfUnits;
    void Start()
    {
        StartCoroutine(SpawnUnit());
    }

    IEnumerator SpawnUnit()
    {
        spawnPos = transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(unit, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        if (numberOfUnits != 0)
        {
            StartCoroutine(SpawnUnit());
            numberOfUnits--;
        }
        else
        {
            StopCoroutine(SpawnUnit());
        }
    }
}
